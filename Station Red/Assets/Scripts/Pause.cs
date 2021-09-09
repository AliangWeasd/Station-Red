using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool canPause = true;
    private bool isPaused = false;

    void Start()
    {
        GameEvents.current.onPauseButtonDown += PauseButtonDown;
        GameEvents.current.onWinStateReached += WinStateReached;
        GameEvents.current.onPlayerDeath += PlayerDeath;

        Time.timeScale = 1;
    }

    void OnDestroy()
    {
        GameEvents.current.onPauseButtonDown -= PauseButtonDown;
        GameEvents.current.onWinStateReached -= WinStateReached;
        GameEvents.current.onPlayerDeath -= PlayerDeath;
    }

    // Update is called once per frame
    void Update()
    {
        if(canPause && Input.GetButtonDown("Submit"))
        {
            GameEvents.current.PauseButtonDown();
        }
    }

    public void PauseButtonPress()
    {
        GameEvents.current.PauseButtonDown();
    }

    public void PauseButtonDown()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }

        if (AudioManager.current != null)
        {
            AudioManager.current.ToggleMusic();
        }

        isPaused = !isPaused;
    }

    public void WinStateReached()
    {
        canPause = false;
    }

    public void PlayerDeath()
    {
        canPause = false;
    }

    public void RestartTime()
    {
        Time.timeScale = 1;
    }
}
