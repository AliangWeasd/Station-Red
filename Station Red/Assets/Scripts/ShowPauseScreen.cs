using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPauseScreen : MonoBehaviour
{
    private bool isPaused = false;

    private CanvasGroup canvasGroup;
    public GameObject pauseCard;

    /*
    void OnEnable()
    {
        GameEvents.current.onPauseButtonDown += PauseButtonDown;
    }*/

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            throw new Exception("CanvasGroup component required to use this script.");
        }

        GameEvents.current.onPauseButtonDown += PauseButtonDown;
    }

    void OnDestroy()
    {
        GameEvents.current.onPauseButtonDown -= PauseButtonDown;
    }

    private void PauseButtonDown()
    {
        isPaused = !isPaused;

        canvasGroup.alpha = Convert.ToInt16(isPaused);
        canvasGroup.interactable = isPaused;
        canvasGroup.blocksRaycasts = isPaused;
    }
}
