using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalkable : MonoBehaviour
{
    Player player;
    MouseControl mouseControl;
    public bool inRange = false;
    [SerializeField] GameObject speechMenu;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        mouseControl = FindObjectOfType<MouseControl>();
    }

    // Update is called once per frame
    void Update()
    {
        Interacted();
    }

    private void OnTriggerStay(Collider collision)
    {
        inRange = true;
    }
    private void OnTriggerExit(Collider collision)
    {
        inRange = false;
    }

    private void Interacted()
    {
        if (inRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && speechMenu.activeSelf == false)
            {
                speechMenu.SetActive(true);
                mouseControl.InternalLockUpdate();
            }
            else if (Input.GetKeyDown(KeyCode.E) && speechMenu.activeSelf == true)
            {
                speechMenu.SetActive(false);
                mouseControl.InternalLockUpdate();
            }
        }
        else { speechMenu.SetActive(false);

        }
    }
}