using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public string personalQuestDetails;
    [SerializeField] TextMeshProUGUI questDetailsText;

    public void SetQuestDetails()
    {
        questDetailsText.text = personalQuestDetails;
    }
}
