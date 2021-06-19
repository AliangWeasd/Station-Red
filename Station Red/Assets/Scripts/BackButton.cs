using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        if (btn = GetComponent<Button>())
        {
            btn.onClick.AddListener(ButtonPressed);
        }
        else
        {
            throw new Exception("Button component required to use this script.");
        }
    }

    public void ButtonPressed()
    {
        SR_MenuEvents.current.ButtonPressed(transform.parent.tag, false);
    }
}
