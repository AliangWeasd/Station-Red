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
        GetComponent<Image>().enabled = true;

        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(true);
        }
    }

    public void Disappear()
    {
        GetComponent<Image>().enabled = false;

        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(false);
        }
    }
}