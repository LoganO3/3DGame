using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Player player;
    public bool inRange = false;
    public GameObject speechMenu;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        speechMenu.SetActive(false);
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
        if(inRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E) && speechMenu.activeSelf == false)
            {
               speechMenu.SetActive(true);
            }
            else if (Input.GetKeyDown(KeyCode.E) && speechMenu.activeSelf == true)
            {
                speechMenu.SetActive(false);
            }
        }
        else {return;}
    }
}
