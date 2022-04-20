using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Player : MonoBehaviour
{
    public GameObject[] weapons;
    public int currentWeapon = 0;
    private int weaponCount;
    public float standardForwardSpeed;
    public float standardBackwardSpeed;
    public float standardStrafeSpeed;
    public float buffTimer;
    public bool isBuffed = false;

    // Start is called before the first frame update
    void Start()
    {
        weaponCount = weapons.Length;
        SwitchWeapon(currentWeapon);;
        standardForwardSpeed = GetComponent<RigidbodyFirstPersonController.MovementSettings>().ForwardSpeed;
        standardBackwardSpeed = GetComponent<RigidbodyFirstPersonController.MovementSettings>().BackwardSpeed;
        standardStrafeSpeed = GetComponent<RigidbodyFirstPersonController.MovementSettings>().StrafeSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentWeapon == 2)
            {
                currentWeapon = 0;
                SwitchWeapon(currentWeapon);
            }
            else if (currentWeapon == 0)
            {
                currentWeapon = 1;
                SwitchWeapon(currentWeapon);
            }
            else if (currentWeapon == 1)
            {
                currentWeapon = 2;
                SwitchWeapon(currentWeapon);
            }
        }
        if (isBuffed)
        {
            StartCoroutine(buff());
            isBuffed = false;
        }
    }

    void SwitchWeapon(int index)
    {

        for (int i = 0; i < weaponCount; i++)
        {
            if (i == index)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }

    public void savePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void loadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        this.GetComponent<Health>().hp = data.health;
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    IEnumerator buff()
    {
        yield return new WaitForSeconds(buffTimer);
        GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MovementSettings>().ForwardSpeed = standardForwardSpeed;
        GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MovementSettings>().BackwardSpeed = standardBackwardSpeed;
        GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MovementSettings>().StrafeSpeed = standardStrafeSpeed;
    }
}