using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCTalkable : MonoBehaviour
{
    Player player;
    MouseControl mouseControl;
    State state;
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] State StartingState;
    public GameObject speechMenu;
    public bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        mouseControl = FindObjectOfType<MouseControl>();
        state = StartingState;
        textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        Interacted();
        ManageState();
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
            }
            else if (Input.GetKeyDown(KeyCode.E) && speechMenu.activeSelf == true)
            {
                speechMenu.SetActive(false);
            }
        }
        else { speechMenu.SetActive(false);

        }
    }

    private void ManageState()
    {
        if (speechMenu.activeSelf == true)
        {
            var NextStates = state.GetNextStates();
            for (int index = 0; index < NextStates.Length; index++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + index))
                {
                    state = NextStates[index];
                }
            }
            textComponent.text = state.GetStateStory();
        }
        else { return; }
    }
}