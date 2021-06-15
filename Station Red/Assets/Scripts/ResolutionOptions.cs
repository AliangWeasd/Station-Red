using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResolutionOptions : MonoBehaviour
{
    private Resolution[] resolutions;
    private int currentResolutionIndex = 0;
    private const string RESOLUTION_PREF_KEY = "resolution";

    // Start is called before the first frame update
    void Start()
    {
        TMPro.TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();

        dropdown.options.Clear();

        resolutions = Screen.resolutions;
        currentResolutionIndex = PlayerPrefs.GetInt(RESOLUTION_PREF_KEY, 0);

        Screen.SetResolution(resolutions[currentResolutionIndex].width, 
            resolutions[currentResolutionIndex].height, 
            Screen.fullScreen, 
            resolutions[currentResolutionIndex].refreshRate);

        foreach (Resolution item in resolutions)
        {
            string res = item.width + "x" + item.height + " (" + item.refreshRate + " hz)";
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = res });
        }

        DropdownItemSelected(dropdown);

        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });

        dropdown.value = currentResolutionIndex;
        dropdown.RefreshShownValue();
    }

    void DropdownItemSelected(TMP_Dropdown dropdown)
    {
        int index = dropdown.value;

        Screen.SetResolution(resolutions[index].width, resolutions[index].height, Screen.fullScreen, resolutions[index].refreshRate);
        PlayerPrefs.SetInt(RESOLUTION_PREF_KEY, index);
    }
}
