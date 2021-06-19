using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public AudioClip audioAttacked;
    public AudioClip audioKeyCollected;
    public AudioClip audioAllKeysCollected;
    public AudioClip audioTimeCount;
    public AudioClip audioHeartLost;

    void Awake()
    {
        if (AudioManager.current == null)
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    { 
        GameEvents.current.onStartingGame += StartingGame;
        GameEvents.current.onPlayerAttacked += PlayerAttacked;
        GameEvents.current.onKeyCollected += KeyCollected;
        GameEvents.current.onAllKeysCollected += AllKeysCollected;
        GameEvents.current.onPlayerDeath += PlayerDeath;

        UIEvents.current.onTimeCount += TimeCount;
        UIEvents.current.onStopTimeCount += StopTimeCount;
        UIEvents.current.onCountHeartLost += CountHeartLost;
    }

    void OnDestroy()
    {
        GameEvents.current.onStartingGame -= StartingGame;
        GameEvents.current.onPlayerAttacked -= PlayerAttacked;
        GameEvents.current.onKeyCollected -= KeyCollected;
        GameEvents.current.onAllKeysCollected -= AllKeysCollected;
        GameEvents.current.onPlayerDeath -= PlayerDeath;

        UIEvents.current.onTimeCount -= TimeCount;
        UIEvents.current.onStopTimeCount -= StopTimeCount;
        UIEvents.current.onCountHeartLost -= CountHeartLost;
    }

    public void StartingGame()
    {
        AudioManager.current.UnpauseMusic();
    }

    public void PlayerAttacked()
    {
        AudioManager.current.PlayEffect(audioAttacked);
    }

    public void KeyCollected()
    {
        AudioManager.current.PlayEffect(audioKeyCollected);
    }

    public void AllKeysCollected()
    {
        AudioManager.current.StopEffect();
        AudioManager.current.PlayEffect(audioAllKeysCollected);
    }

    public void PlayerDeath()
    {
        AudioManager.current.PauseMusic();
    }

    public void TimeCount()
    {
        AudioManager.current.PlayEffect(audioTimeCount);
    }

    public void StopTimeCount()
    {
        AudioManager.current.StopEffect();
    }

    public void CountHeartLost()
    {
        AudioManager.current.PlayEffect(audioHeartLost);
    }
}
