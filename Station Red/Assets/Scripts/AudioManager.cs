using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioS;
    public AudioClip menuMusic;
    public AudioClip levelMusic;

    private bool isPaused = false;

    // Start is called before the first frame update
    void Awake()
    {
        audioS.clip = menuMusic;
        audioS.Play();

        SceneManager.activeSceneChanged += ChangedActiveScene;
        GameEvents.current.onStartingGame += StartingGame;
        GameEvents.current.onPlayerDeath += PlayerDeath;
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;

        if (next.name == "TitleScene")
        {
            audioS.clip = menuMusic;
            audioS.Play();
        }
    }

    private void StartingGame()
    {
        if (isPaused)
        {
            audioS.UnPause();
            StartCoroutine(IncreaseVolume());
            isPaused = false;
        }
        else
        {
            audioS.clip = levelMusic;
            audioS.Play();
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
