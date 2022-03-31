using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] weapons;
    public int currentWeapon = 0;
    private int weaponCount;

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
            if (currentWeapon == 1)
            {
                currentWeapon = 0;
                SwitchWeapon(currentWeapon);
            }
            else if (currentWeapon == 0)
            {
                currentWeapon = 1;
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
  
}