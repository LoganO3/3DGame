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
    Interactable interactable;
    [SerializeField] TextMeshProUGUI textComponent;
    [SerializeField] State StartingState;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        mouseControl = FindObjectOfType<MouseControl>();
        interactable = FindObjectOfType<Interactable>();
        state = StartingState;
        textComponent.text = state.GetStateStory();
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        if (interactable.speechMenu.activeSelf == true)
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