using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterType : MonoBehaviour
{
    Quests quests;
    [SerializeField] bool isSlime = false;
    [SerializeField] bool isSkeleton = false;

    // Start is called before the first frame update
    void Start()
    {
        quests = FindObjectOfType<Quests>();
    }

    public void MonsterTypeChecker()
    { 
        if (isSlime == true)
        {
            quests.slimesKilled = quests.slimesKilled + 1;
        }
        else if (isSkeleton == true)
        {
            quests.skeletonsKilled = quests.skeletonsKilled + 1;
        }
        else { return; }
    }
}
