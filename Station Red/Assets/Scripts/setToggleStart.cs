using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setToggleStart : MonoBehaviour
{
    private int screenInt;

    private const string FULLSCREEN_PREF_KEY = "fullscreen";

    // Start is called before the first frame update
    void Start()
    {
        screenInt = PlayerPrefs.GetInt(FULLSCREEN_PREF_KEY);

        if (screenInt == 1)
        {
            GetComponent<Toggle>().isOn = true;
        }
        else
        {
            GetComponent<Toggle>().isOn = false;
        }
    }
}
