using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalkable : MonoBehaviour
{
    Player player;
    public bool inRange = false;
    [SerializeField] GameObject speechMenu;

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
            if (Input.GetKeyDown(KeyCode.E))
            {
                speechMenu.SetActive(true);
            }
        }
        else {speechMenu.SetActive(true);}
    }
}