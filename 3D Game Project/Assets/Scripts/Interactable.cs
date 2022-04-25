using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Player player;
    public bool inRange = false;
    SceneLoader sceneLoader;
    bool Inside;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        sceneLoader = FindObjectOfType<SceneLoader>();
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
            if (Input.GetKeyDown(KeyCode.E) && Inside == false)
            {
                sceneLoader.LoadNextScene();
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                sceneLoader.LoadGameScene();
            }
        }
        else {return;}
    }
}
