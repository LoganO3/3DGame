using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
    public GameObject questMenu;
    public int slimesKilled = 0;
    public int skeletonsKilled = 0;

    // Update is called once per frame
    void Update()
    {
        QuestMenuActivator();
    }

    private void QuestMenuActivator()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && questMenu.activeSelf == false)
        {
            Time.timeScale = 0;
            questMenu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && questMenu.activeSelf == true)
        {
            Time.timeScale = 1;
            questMenu.SetActive(false);
        }
    }
}
