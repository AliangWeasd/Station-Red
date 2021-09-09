using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource effectsSource;

    private bool isPaused = false;

    private float masterVolume;
    private float musicVolume;
    private float effectsVolume;
    private bool isMute;

    private const string MASTER_VOLUME = "mastervolume";
    private const string MUSIC_VOLUME = "musicvolume";
    private const string EFFECTS_VOLUME = "effectsvolume";
    private const string MUTE_TOGGLE = "mutetoggle";

    // Singleton
    public static AudioManager current = null;

    // Start is called before the first frame update
    void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (current == null)
        {
            current = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (current != this)
        {
            Destroy(gameObject);
        }

        masterVolume = PlayerPrefs.GetFloat(MASTER_VOLUME, 1);
        musicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME, 1);
        effectsVolume = PlayerPrefs.GetFloat(EFFECTS_VOLUME, 1);
        isMute = (PlayerPrefs.GetInt(MUTE_TOGGLE, 0) == 1);

        ChangeVolume();
        ChangeMute(isMute);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    // Play a single clip through the sound effects source.
    public void PlayEffect(AudioClip clip)
    {
        effectsSource.clip = clip;
        effectsSource.PlayOneShot(clip);
    }

    // Play a single clip through the music source.
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource.clip == null || musicSource.clip.name != clip.name)
        {
            musicSource.clip = clip;
            musicSource.Play();
        }

        if(isPaused)
        {
            UnpauseMusic();
            StartCoroutine(IncreaseVolume());
        }
    }

    public void StopEffect()
    {
        effectsSource.Stop();
    }

    public void ToggleMusic()
    {
        if (!isPaused)
        {
            musicSource.Pause();
            isPaused = true;
        }
        else
        {
            musicSource.UnPause();
            isPaused = false;
        }
    }

    public void PauseMusic()
    {
        if (!isPaused)
        {
            musicSource.Pause();
        }
        isPaused = true;
    }

    public void UnpauseMusic()
    {
        if (isPaused)
        {
            musicSource.UnPause();
        }
        isPaused = false;
    }

    public void ResetPause()
    {
        isPaused = false;
    }

    IEnumerator IncreaseVolume()
    {
        float volumeSliderValue = masterVolume * musicVolume;
        float pitchSliderValue = 1;
        float startVolume = volumeSliderValue / 2;
        float startPitch = 0;

        float i = 0;
        float timeToDecrease = 2;

        if (musicSource.pitch > 0)
        {
            musicSource.pitch = startPitch;
            //musicSource.volume = startVolume;

            while (i < timeToDecrease)
            {
                musicSource.pitch = pitchSliderValue * i / timeToDecrease;
                //musicSource.volume = volumeSliderValue * i / (timeToDecrease * 2) + startVolume;

                i += Time.deltaTime;
                yield return new WaitForFixedUpdate();
            }
        }

        yield return null;
    }

    public void ChangeMasterVolume(float masterVolume)
    {
        this.masterVolume = masterVolume;
        PlayerPrefs.SetFloat(MASTER_VOLUME, masterVolume);
        ChangeVolume();
    }

    public void ChangeMusicVolume(float musicVolume)
    {
        this.musicVolume = musicVolume;
        PlayerPrefs.SetFloat(MUSIC_VOLUME, musicVolume);
        ChangeVolume();
    }

    public void ChangeEffectsVolume(float effectsVolume)
    {
        this.effectsVolume = effectsVolume;
        PlayerPrefs.SetFloat(EFFECTS_VOLUME, effectsVolume);
        ChangeVolume();
    }

    public void ChangeVolume()
    {
        musicSource.volume = masterVolume * musicVolume;
        effectsSource.volume = masterVolume * effectsVolume;
    }

    public void ChangeMute(bool isMute)
    {
        musicSource.mute = isMute;
        effectsSource.mute = isMute;

        PlayerPrefs.SetInt(MUTE_TOGGLE, isMute ? 1 : 0);
    }
}
