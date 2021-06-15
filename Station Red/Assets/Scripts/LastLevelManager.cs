using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelManager : MonoBehaviour
{
    private const string LAST_LEVEL = "lastlevel";

    public GameObject MainPanel;
    public GameObject LevelPanel;

    // Start is called before the first frame update
    void Start()
    {
        int lastlevel = PlayerPrefs.GetInt(LAST_LEVEL);

        if(lastlevel != -1)
        {
            MainPanel.GetComponent<ShowMenuCard>().LaunchInstant();
            LevelPanel.GetComponent<ShowMenuCard>().LaunchInstant();
        }
    }

    public void SetLastLevel(int level)
    {
        PlayerPrefs.SetInt(LAST_LEVEL, level);
    }
}
