using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float hp = 5;
    MonsterType monsterType;
    SceneLoader sceneLoader;

    private void Start()
    {
        monsterType = GetComponent<MonsterType>();
        sceneLoader = GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            if (GetComponent<Player>() == false)
            {
                monsterType.MonsterTypeChecker();
                Destroy(gameObject);
            }
            else
            {
                sceneLoader.LoadDeathScene();
                Destroy(gameObject);
            }
        }
    }
}
