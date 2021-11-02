using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        if (btn = GetComponent<Button>())
        {
            btn.onClick.AddListener(Pause);
        }
        else
        {
            throw new Exception("Button component required to use this script.");
        }
    }

    void Pause()
    {
        GameEvents.current.PauseButtonDown();
    }
}
