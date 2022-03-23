using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLocker : MonoBehaviour
{
    MouseControl mouseControl;
    NPCTalkable nPCTalkable;
    InventoryControl inventoryControl;

    // Start is called before the first frame update
    void Start()
    {
        mouseControl = FindObjectOfType<MouseControl>();
        nPCTalkable = FindObjectOfType<NPCTalkable>();
        inventoryControl = FindObjectOfType<InventoryControl>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            mouseControl.Unlocked();  
        }
        else if (Time.timeScale == 1)
        {
            if (inventoryControl.Inventory.activeSelf == true)
            {
                mouseControl.Unlocked();
            }
            else if (nPCTalkable.speechMenu.activeSelf == true)
            {
                mouseControl.Unlocked();
            }
            else
            {
                mouseControl.Locked();
            }
        }
    }
}
