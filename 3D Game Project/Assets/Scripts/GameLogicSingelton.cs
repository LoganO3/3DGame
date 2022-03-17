using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicSingelton : MonoBehaviour
{
    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int numberGameStatus = FindObjectsOfType<GameLogicSingelton>().Length;
        if (numberGameStatus > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
