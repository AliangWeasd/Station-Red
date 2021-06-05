using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action onStartingGame;
    public event Action onStartGamePoint;
    public event Action onPauseButtonDown;
    public event Action onWinStateReached;
    public event Action onKeyCollected;
    public event Action onAllKeysCollected;
    public event Action onPlayerAttacked;
    public event Action onPlayerDeath;
    public event Action onTimeCount;
    public event Action onStopTimeCount;
    public event Action onCountHeartLost;

    public void StartingGame()
    {
        if (onStartingGame != null)
        {
            onStartingGame();
        }
    }

    public void StartGamePoint()
    {
        if (onStartGamePoint != null)
        {
            onStartGamePoint();
        }
    }

    public void PauseButtonDown()
    {
        if(onPauseButtonDown != null)
        {
            onPauseButtonDown();
        }
    }

    public void WinStateReached()
    {
        if(onWinStateReached != null)
        {
            onWinStateReached();
        }
    }

    public void KeyCollected()
    {
        if(onKeyCollected != null)
        {
            onKeyCollected();
        }
    }

    public void AllKeysCollected()
    {
        if (onAllKeysCollected != null)
        {
            onAllKeysCollected();
        }
    }

    public void PlayerAttacked()
    {
        if(onPlayerAttacked != null)
        {
            onPlayerAttacked();
        }
    }

    public void PlayerDeath()
    {
        if(onPlayerDeath != null)
        {
            onPlayerDeath();
        }
    }

    public void TimeCount()
    {
        if (onTimeCount != null)
        {
            onTimeCount();
        }
    }

    public void StopTimeCount()
    {
        if (onStopTimeCount != null)
        {
            onStopTimeCount();
        }
    }

    public void CountHeartLost()
    {
        if(onCountHeartLost != null)
        {
            onCountHeartLost();
        }
    }
}
