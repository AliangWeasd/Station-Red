using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenOption : MonoBehaviour
{
    private const string FULLSCREEN_PREF_KEY = "fullscreen";

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;

        if(isFullScreen == false)
        {
            PlayerPrefs.SetInt(FULLSCREEN_PREF_KEY, 0);
        }
        else
        {
            isFullScreen = true;
            PlayerPrefs.SetInt(FULLSCREEN_PREF_KEY, 1);
        }
    }
}
