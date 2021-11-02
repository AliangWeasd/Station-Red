using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    private Button btn;
    private ShowMenuCard func;

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

        if ((func = GetComponentInParent<ShowMenuCard>()) == null)
        {
            throw new Exception("Parent component <ShowMenuCard> required to use this script.");
        }
    }

    public void ButtonPressed()
    {
        func.setAppear(false);
    }
}
