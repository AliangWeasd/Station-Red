using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    private string volumeKey = "default";

    private string[] volumeTag = { "mastervolume", "musicvolume", "effectsvolume" };

    void Start()
    {
        volumeKey = gameObject.tag;

        Slider sliderVolume = GetComponent<Slider>();
        sliderVolume.value = PlayerPrefs.GetFloat(volumeKey, 1);

        if (AudioManager.current != null)
        {
            sliderVolume.onValueChanged.AddListener(delegate { VolumeChange(sliderVolume); });
        }
    }

    void VolumeChange(Slider sliderVolume)
    {
        if (gameObject.tag == volumeTag[0]) {
            AudioManager.current.ChangeMasterVolume(sliderVolume.value);
        } else if (gameObject.tag == volumeTag[1]) {
            AudioManager.current.ChangeMusicVolume(sliderVolume.value);
        } else if (gameObject.tag == volumeTag[2]) {
            AudioManager.current.ChangeEffectsVolume(sliderVolume.value);
        }
    }
}
