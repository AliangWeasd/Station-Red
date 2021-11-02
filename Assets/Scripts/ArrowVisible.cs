using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowVisible : MonoBehaviour
{
    public bool isLeftArrow = true;

    void Start()
    {
        if (isLeftArrow)
        {
            SR_MenuEvents.current.onIndexLeast += IndexLeast;
        }
        else
        {
            SR_MenuEvents.current.onIndexMost += IndexMost;
        }

        SR_MenuEvents.current.onIndexBetween += IndexBetween;

        /*
        Slider sliderVolume = GetComponent<Slider>();
        sliderVolume.value = PlayerPrefs.GetFloat(volumeKey, 1);

        if (AudioManager.current != null)
        {
            sliderVolume.onValueChanged.AddListener(delegate { VolumeChange(sliderVolume); });
        }
        */
    }

    void OnDestroy()
    {
        if (isLeftArrow)
        {
            SR_MenuEvents.current.onIndexLeast -= IndexLeast;
        }
        else
        {
            SR_MenuEvents.current.onIndexMost -= IndexMost;
        }

        SR_MenuEvents.current.onIndexBetween -= IndexBetween;
    }

    public void IndexLeast()
    {
        this.GetComponent<Image>().enabled = false;
        this.GetComponent<Button>().enabled = false;
    }

    public void IndexMost()
    {
        this.GetComponent<Image>().enabled = false;
        this.GetComponent<Button>().enabled = false;
    }

    public void IndexBetween()
    {
        this.GetComponent<Image>().enabled = true;
        this.GetComponent<Button>().enabled = true;
    }
}
