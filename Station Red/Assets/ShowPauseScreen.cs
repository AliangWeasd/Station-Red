using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowPauseScreen : MonoBehaviour
{
    private Image pauseCard;
    private bool isPaused = false;

    void Start()
    {
        GameEvents.current.onPauseButtonDown += PauseButtonDown;
        pauseCard = GetComponent<Image>();
    }

    private void PauseButtonDown()
    {
        if(isPaused)
        {
            pauseCard.enabled = false;
            Time.timeScale = 1;

            for (int a = 0; a < transform.childCount; a++)
            {
                transform.GetChild(a).gameObject.SetActive(false);
            }
        }
        else
        {
            pauseCard.enabled = true;
            Time.timeScale = 0;

            for (int a = 0; a < transform.childCount; a++)
            {
                transform.GetChild(a).gameObject.SetActive(true);
            }
        }

        isPaused = !isPaused;
    }

    public void RestartTime()
    {
        Time.timeScale = 1;
    }
}
