using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAudioManager : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip audioAttacked;
    public AudioClip audioKeyCollected;
    public AudioClip audioAllKeysCollected;
    public AudioClip audioTimeCount;
    public AudioClip audioHeartLost;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onPlayerAttacked += PlayerAttacked;
        GameEvents.current.onKeyCollected += KeyCollected;
        GameEvents.current.onAllKeysCollected += AllKeysCollected;
        GameEvents.current.onTimeCount += TimeCount;
        GameEvents.current.onStopTimeCount += StopTimeCount;
        GameEvents.current.onCountHeartLost += CountHeartLost;
    }

    public void PlayerAttacked()
    {
        audioS.PlayOneShot(audioAttacked);
    }

    public void KeyCollected()
    {
        audioS.PlayOneShot(audioKeyCollected);
    }

    public void AllKeysCollected()
    {
        audioS.Stop();
        audioS.PlayOneShot(audioAllKeysCollected);
    }

    public void TimeCount()
    {
        audioS.PlayOneShot(audioTimeCount);
    }

    public void StopTimeCount()
    {
        audioS.Stop();
    }

    public void CountHeartLost()
    {
        audioS.PlayOneShot(audioHeartLost);
    }
}
