using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLevelBootManager : MonoBehaviour
{
    private const string LAST_LEVEL = "lastlevel";

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt(LAST_LEVEL, -1);
    }
}
