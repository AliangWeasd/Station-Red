using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicManager : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip gameMusic;

    private bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        audioS.clip = gameMusic;
        audioS.Play();

        GameEvents.current.onStartingGame += StartingGame;
        GameEvents.current.onPlayerDeath += PlayerDeath;
    }

    void OnDestroy()
    {
        GameEvents.current.onStartingGame -= StartingGame;
        GameEvents.current.onPlayerDeath -= PlayerDeath;
    }

    private void StartingGame()
    {
        if (isPaused)
        {
            audioS.UnPause();
            StartCoroutine(IncreaseVolume());
            isPaused = false;
        }
    }

    private void PlayerDeath()
    {
        audioS.Pause();
        isPaused = true;
    }

    IEnumerator IncreaseVolume()
    {
        float volumeSliderValue = audioS.volume;
        float pitchSliderValue = audioS.pitch;
        float startVolume = 0;
        float startPitch = 0;

        float i = 0;
        float timeToDecrease = 2;

        if (audioS.pitch > 0)
        {
            audioS.pitch = startVolume;
            audioS.volume = startPitch;

            while (i < timeToDecrease)
            {
                audioS.pitch = pitchSliderValue * i / timeToDecrease;
                audioS.volume = volumeSliderValue * i / timeToDecrease;

                i += Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
        }

        yield return null;
    }
}
