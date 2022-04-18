using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] weapons;
    public int currentWeapon = 0;
    private int weaponCount;
    private float standardSpeedForward;
    private float standardSpeedBackward;
    private float standardSpeedStrafe;
    public float buffTimer;

    // Start is called before the first frame update
    void Start()
    {
        weaponCount = weapons.Length;
        SwitchWeapon(currentWeapon);;
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

    public void resetSpeed()
    {
        GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MovementSettings>().ForwardSpeed = standardSpeedForward;
        GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MovementSettings>().BackwardSpeed = standardSpeedBackward;
        GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController.MovementSettings>().StrafeSpeed = standardSpeedStrafe;
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
}