using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMenuCard : MonoBehaviour
{
    public AnimationCurve showCurve;
    public AnimationCurve leaveCurve;
    public float timeInSec = 1f;

    private Vector2 CENTERED_ANCHOR = new Vector2(0.5f,0.5f);
    private Vector2 CENTERED_PIVOT = new Vector2(0.5f,0.5f);
    private Vector2 orig_anchor = new Vector2();
    private Vector2 orig_pivot = new Vector2();

    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            throw new Exception("CanvasGroup component required to use this script.");
        }

        rectTransform = GetComponent<RectTransform>();

        if ((rectTransform = GetComponent<RectTransform>()) is null)
        {
            throw new Exception("RectTransform component required to use this script.");
        }

        orig_anchor = rectTransform.anchorMax;
        orig_pivot = rectTransform.pivot;
    }

    IEnumerator Launch()
    {
        Vector2 anchorChange = CENTERED_ANCHOR - orig_anchor;
        Vector2 pivotChange = CENTERED_PIVOT - orig_pivot;

        float timer = 0.0f;
        while (timer <= timeInSec)
        {
            float curveDelta = showCurve.Evaluate(timer / timeInSec);
            Vector2 anchorDelta = new Vector2(orig_anchor.x + (anchorChange.x * curveDelta),
                                              orig_anchor.y + (anchorChange.y * curveDelta));

            rectTransform.anchorMin = anchorDelta;
            rectTransform.anchorMax = anchorDelta;

            rectTransform.pivot = new Vector2(orig_pivot.x + (pivotChange.x * curveDelta),
                                              orig_pivot.y + (pivotChange.y * curveDelta));

            timer += Time.deltaTime;
            yield return null;
        }
        rectTransform.anchorMin = CENTERED_ANCHOR;
        rectTransform.anchorMax = CENTERED_ANCHOR;
        rectTransform.pivot = CENTERED_PIVOT;
    }

    IEnumerator Hide()
    {
        Vector2 anchorChange = orig_anchor - CENTERED_ANCHOR;
        Vector2 pivotChange = orig_pivot - CENTERED_PIVOT;

        float timer = 0.0f;
        while (timer <= timeInSec)
        {
            float curveDelta = leaveCurve.Evaluate(timer / timeInSec);
            Vector2 anchorDelta = new Vector2(CENTERED_ANCHOR.x + (anchorChange.x * curveDelta),
                                              CENTERED_ANCHOR.y + (anchorChange.y * curveDelta));

            rectTransform.anchorMin = anchorDelta;
            rectTransform.anchorMax = anchorDelta;

            rectTransform.pivot = new Vector2(CENTERED_PIVOT.x + (pivotChange.x * curveDelta),
                                              CENTERED_PIVOT.y + (pivotChange.y * curveDelta));

            timer += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchorMin = orig_anchor;
        rectTransform.anchorMax = orig_anchor;
        rectTransform.pivot = orig_pivot;
    }

    public void LaunchPage()
    {
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
        StartCoroutine(Launch());
    }

    public void HidePage()
    {
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        StartCoroutine(Hide());
    }

    public void LaunchInstant()
    {
        rectTransform.anchorMin = CENTERED_ANCHOR;
        rectTransform.anchorMax = CENTERED_ANCHOR;
        rectTransform.pivot = CENTERED_PIVOT;
    }

    public void HideInstant()
    {
        rectTransform.anchorMin = orig_anchor;
        rectTransform.anchorMax = orig_anchor;
        rectTransform.pivot = orig_pivot;
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
            HidePage();
        }
        else
        {
            canvasGroup.alpha = Convert.ToInt32(isOn);
            canvasGroup.interactable = isOn;
            canvasGroup.blocksRaycasts = isOn;
        }
    }
}