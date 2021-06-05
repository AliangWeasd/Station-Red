using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool canPause = true;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onWinStateReached += WinStateReached;
        GameEvents.current.onPlayerDeath += PlayerDeath;
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

    public void WinStateReached()
    {
        canPause = false;
    }

    public void PlayerDeath()
    {
        canPause = false;
    }
}
