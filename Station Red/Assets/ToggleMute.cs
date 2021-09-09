using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleMute : MonoBehaviour
{
    private int isMute;

    private const string MUTE_PREF_KEY = "mutetoggle";

    // Start is called before the first frame update
    void Start()
    {
        isMute = PlayerPrefs.GetInt(MUTE_PREF_KEY, 0);

        Toggle muteToggle = GetComponent<Toggle>();

        muteToggle.isOn = (isMute == 1);

        if (AudioManager.current != null)
        {
            muteToggle.onValueChanged.AddListener(delegate { ChangeMute(muteToggle); });
        }
    }

    void ChangeMute(Toggle muteToggle)
    {
        AudioManager.current.ChangeMute(muteToggle.isOn);
    }
}
