using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMenuCard : MonoBehaviour
{
    public AnimationCurve showCurve;
    public AnimationCurve leaveCurve;
    public Vector3 downPos = new Vector3();
    public Vector3 upPos = new Vector3();
    public float timeInSec = 1f;

    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            throw new Exception("CanvasGroup component required to use this script.");
        }
    }

    IEnumerator Launch()
    {
        Vector3 distance = upPos - downPos;
        Vector3 startPos = downPos;

        float timer = 0.0f;
        while (timer <= timeInSec)
        {
            Vector3 pos = startPos + (distance * showCurve.Evaluate(timer / timeInSec));
            transform.position = pos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = upPos;
    }

    IEnumerator Hide()
    {
        Vector3 distance = downPos - upPos;
        Vector3 startPos = upPos;

        float timer = 0.0f;
        while (timer <= timeInSec)
        {
            Vector3 pos = startPos + (distance * leaveCurve.Evaluate(timer / timeInSec));
            transform.position = pos;

            timer += Time.deltaTime;
            yield return null;
        }
        transform.position = downPos;
    }

    public void LaunchPage()
    {
        StartCoroutine(Launch());
    }

    public void HidePage()
    {
        StartCoroutine(Hide());
    }

    public void LaunchInstant()
    {
        transform.position = upPos;
    }

    public void HideInstant()
    {
        transform.position = downPos;
    }

    public void Appear()
    {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void Disappear()
    {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void setAppear(bool isOn)
    {
        if (this.gameObject.tag == "Menu")
        {
            StartCoroutine(Hide());
        }
        else
        {
            canvasGroup.alpha = Convert.ToInt32(isOn);
            canvasGroup.interactable = isOn;
            canvasGroup.blocksRaycasts = isOn;
        }
    }
}