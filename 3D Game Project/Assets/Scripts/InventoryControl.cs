using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    public GameObject Inventory;
    public Player player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            OpenAndCloseInv();
        }
    }

    public void OpenAndCloseInv()
    {
        if (!player) { return; }
        else
        {
            if (Inventory.activeSelf == true)
            {
                Inventory.SetActive(false);
            }
            else if (Inventory.activeSelf == false)
            {
                Inventory.SetActive(true);
            }
        }
    }
}
