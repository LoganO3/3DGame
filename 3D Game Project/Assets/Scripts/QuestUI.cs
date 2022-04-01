using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public string personalQuestDetails;
    float trackedNumber;
    float targetNumber;
    [SerializeField] bool isKillQuest = false;
    [SerializeField] bool isCollectionQuest = false;
    [SerializeField] bool trackingSlimeKills = false;
    [SerializeField] bool trackingSkeletonKills = false;
    [SerializeField] TextMeshProUGUI questDetailsText;
    TextMeshProUGUI questTrackerText;
    TextMeshProUGUI questTarget;

    public void Start()
    {
        if (trackingSlimeKills == true)
        {
            trackedNumber = FindObjectOfType<Quests>().slimesKilled;
            questTarget.text = " Slimes";
        }
        else if (trackingSkeletonKills == true)
        {
            trackedNumber = FindObjectOfType<Quests>().skeletonsKilled;
            questTarget.text = " Skeletons";
        }
    }

    public void SetQuestDetails()
    {
        if (isKillQuest)
        {
            questTrackerText.text = "You Have Killed " + trackedNumber + " Out Of " + targetNumber + questTarget;
        }
        else if (isCollectionQuest)
        {
            questTrackerText.text = "You Have Collected " + trackedNumber + " Out Of " + targetNumber + " " + questTarget;
        }
        questDetailsText.text = personalQuestDetails;
    }
}
