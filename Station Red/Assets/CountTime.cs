using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
    public int scrollTimeFrames = 60;

    public Text timerText;
    public Image[] timer;
    public Sprite[] number;

    void PrintTime(string time)
    {
        for (int i = 0; i < time.Length; i++)
        {
            char digit = time[i];

            timer[i].sprite = number[digit - '0'];
        }
    }

    IEnumerator Count(int time)
    {
        int start = 0;
        int step = time / scrollTimeFrames;

        do
        {
            PrintTime(string.Format("{0:0000000}", start));

            start += step;

            yield return new WaitForEndOfFrame();
        } while (start < time);

        PrintTime(string.Format("{0:0000000}", time));
    }

    IEnumerator CountInstant(int time)
    {
        PrintTime(string.Format("{0:0000000}", time));
        yield return null;
    }
}
