using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public string personalQuestDetails;
    string personalQuestTracker;
    float trackedNumber;
    [SerializeField] float targetNumber;
    [SerializeField] bool trackingSlimeKills = false;
    [SerializeField] bool trackingSkeletonKills = false;
    [SerializeField] TextMeshProUGUI questDetailsText;
    [SerializeField] TextMeshProUGUI questTrackerText;


    public void Start()
    {
        if (trackingSlimeKills == true)
        {
            trackedNumber = FindObjectOfType<Quests>().slimesKilled;
        }
        else if (trackingSkeletonKills == true)
        {
            trackedNumber = FindObjectOfType<Quests>().skeletonsKilled;
        }
    }

    public void Update()
    {
        if (trackedNumber == targetNumber)
        {
            gameObject.GetComponent<TextMeshPro>().color = new Color(0.2f, 0.2f, 0.2f, 1.0f);
        }
            personalQuestTracker = trackedNumber + " / " +targetNumber;
    }

    public void SetQuestDetails()
    {
        questTrackerText.text = personalQuestTracker;
        questDetailsText.text = personalQuestDetails;
    }
}
