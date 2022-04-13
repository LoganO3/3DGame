using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public string personalQuestDetails;
    string personalQuestTracker;
    float trackedNumber;
    bool isActive;
    [SerializeField] GameObject questDisplay;
    [SerializeField] float targetNumber;
    [SerializeField] bool trackingSlimeKills = false;
    [SerializeField] bool trackingSkeletonKills = false;
    [SerializeField] TextMeshProUGUI questDetailsText;
    [SerializeField] TextMeshProUGUI questTrackerText;

    public void Update()
    {
        Debug.Log(questDisplay);
        if (trackedNumber >= targetNumber)
        {
            questDisplay.GetComponent<TextMeshProUGUI>().color = new Color32 (150, 150, 150, 255);
        }
        if (trackingSlimeKills == true)
        {
            trackedNumber = FindObjectOfType<Quests>().slimesKilled;
        }
        else if (trackingSkeletonKills == true)
        {
            trackedNumber = FindObjectOfType<Quests>().skeletonsKilled;
        }
        personalQuestTracker = trackedNumber + " / " + targetNumber;
        if (isActive == true)
        {
            questTrackerText.text = personalQuestTracker;
        }
        if(questDetailsText.text != personalQuestDetails)
        {
            isActive = false;
        }
    }

    public void SetQuestDetails()
    {
        isActive = true;
        questDetailsText.text = personalQuestDetails;
    }
}
