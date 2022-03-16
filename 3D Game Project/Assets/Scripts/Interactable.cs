using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Player player;
    public bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Interacted();
    }

    private void OnTriggerStay(Collider collision)
    {
        Debug.Log("True");
        inRange = true;
    }
    private void OnTriggerExit(Collider collision)
    {
        Debug.Log("False");
        inRange = false;
    }

    private void Interacted()
    {
        if(inRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Talk");
            }
        }
        else {return;}
    }
}
