using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisappearOnWin : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            throw new Exception("CanvasGroup component required to use this script.");
        }

        GameEvents.current.onWinStateReached += WinStateReached;
    }

    void OnDestroy()
    {
        GameEvents.current.onWinStateReached -= WinStateReached;
    }

    public void WinStateReached()
    {
        canvasGroup.alpha = 0;
    }
}
