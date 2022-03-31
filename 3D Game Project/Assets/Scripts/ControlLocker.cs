using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlLocker : MonoBehaviour
{
    MouseControl mouseControl;
    Interactable interactable;
    Quests quests;

    // Start is called before the first frame update
    void Start()
    {
        mouseControl = FindObjectOfType<MouseControl>();
        quests = FindObjectOfType<Quests>();
        interactable = FindObjectOfType<Interactable>();
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
            mouseControl.Locked();
        }
    }
}
