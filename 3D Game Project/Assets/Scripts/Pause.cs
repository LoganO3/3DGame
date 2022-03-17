using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseCanvas;
    public Player player;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        player = FindObjectOfType<Player>();
        if (Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (!player) { return; }
        else
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseCanvas.SetActive(true);
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                pauseCanvas.SetActive(false);
            }
        }
    }

    public void removePauseMenu()
    {
        if (Time.timeScale == 0) { pauseCanvas.SetActive(false); }
        else { return; }
        Time.timeScale = 1;
    }
}