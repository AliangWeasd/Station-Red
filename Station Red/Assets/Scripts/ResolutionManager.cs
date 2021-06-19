using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    public int width;
    public int height;

    private Text resolutionText;
    private Resolution[] resolutions;

    private int currentResolutionIndex = 0;

    private const string RESOLUTION_PREF_KEY = "resolution";

    // Singleton
    public static ResolutionManager current = null;

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

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        resolutions = Screen.resolutions;
        currentResolutionIndex = PlayerPrefs.GetInt(RESOLUTION_PREF_KEY, 0);
    }
    public void SetWidth(int newWidth)
    {
        width = newWidth;
    }

    public void SetHeight(int newHeight)
    {
        height = newHeight;
    }

    public void SetRes()
    {
        Screen.SetResolution(width, height, false);
    }

    private void SetResolutionText(Resolution resolution)
    {
        resolutionText.text = resolution.width + "x" + resolution.height;
    }

    private void SetAndApplyResolution(int newResolutionIndex)
    {
        currentResolutionIndex = newResolutionIndex;
        ApplyCurrentResolution();
    }

    private void ApplyCurrentResolution()
    {
        ApplyResolution(resolutions[currentResolutionIndex]);
    }

    private void ApplyResolution(Resolution resolution)
    {
        SetResolutionText(resolution);

        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        PlayerPrefs.SetInt(RESOLUTION_PREF_KEY, currentResolutionIndex);
    }

    public void ApplyChanges()
    {
        SetAndApplyResolution(currentResolutionIndex);
    }
}
