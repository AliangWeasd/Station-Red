using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPauseScreen : MonoBehaviour
{
    private Image pauseCard;
    private bool isPaused = false;
    /*
    void OnEnable()
    {
        GameEvents.current.onPauseButtonDown += PauseButtonDown;
    }*/

    void Start()
    {
        GameEvents.current.onPauseButtonDown += PauseButtonDown;
        pauseCard = GetComponent<Image>();

        setAppear(false);
    }

    void OnDestroy()
    {
        GameEvents.current.onPauseButtonDown -= PauseButtonDown;
    }

    private void PauseButtonDown()
    {
        if(isPaused)
        {
            setAppear(false);
        }
        else
        {
            setAppear(true);
        }

        isPaused = !isPaused;
    }

    void setAppear(bool isOn)
    {
        pauseCard.enabled = isOn;

        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(isOn);
        }
    }
}
