using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountTimeText : MonoBehaviour
{
    public int scrollTimeFrames = 60;

    private int time = 0;   // time is in milliseconds.
    private string timerText = "0000000";

    private bool isIncrementing = true;
    private int healthLost = 0;

    private TMP_Text UItext;

    void Start()
    {
        UItext = GetComponent<TMP_Text>();

        if (UItext == null)
        {
            throw new Exception("TextMeshProUGUI component required to use this script.");
        }

        UIEvents.current.onStopTimeCount += StopTimeCount;

        if (this.tag == "RecordTime")
        {
            UIEvents.current.onStartRecordCount += StartRecordCount;
            UIEvents.current.onRecordTime += RecordTime;
        }
        else if (this.tag == "CurrentTime")
        {
            UIEvents.current.onStartCurrentCount += StartCurrentCount;
            UIEvents.current.onCurrentTime += CurrentTime;
        }
        else if (this.tag == "FailTime")
        {
            UIEvents.current.onStartFailCount += StartFailCount;
            UIEvents.current.onFailTime += FailTime;
        }
    }

    void OnDestroy()
    {
        UIEvents.current.onStopTimeCount -= StopTimeCount;

        if (this.tag == "RecordTime")
        {
            UIEvents.current.onStartRecordCount -= StartRecordCount;
            UIEvents.current.onRecordTime -= RecordTime;
        }
        else if (this.tag == "CurrentTime")
        {
            UIEvents.current.onStartCurrentCount -= StartCurrentCount;
            UIEvents.current.onCurrentTime -= CurrentTime;
        }
        else if (this.tag == "FailTime")
        {
            UIEvents.current.onStartFailCount -= StartFailCount;
            UIEvents.current.onFailTime -= FailTime;
        }
    }

    private void StartRecordCount(int time)
    {
        this.time = time;
    }

    private void StartCurrentCount(int time, int heartsLost)
    {
        this.time = time;
        healthLost = heartsLost;
    }

    private void StartFailCount(int time)
    {
        this.time = time;
    }

    private void RecordTime()
    {
        StartCoroutine(Count());
    }

    private void CurrentTime()
    {
        StartCoroutine(Count());
    }

    private void FailTime()
    {
        StartCoroutine(Count());
    }

    private void StopTimeCount()
    {
        isIncrementing = false;
    }

    void PrintTime(string time)
    {
        string timeWithColons = time.Insert(2, ":").Insert(5, ":");

        UItext.text = timeWithColons;
        UItext.text = "<mspace=0.6em>" + UItext.text + "</mspace>";
    }

    void AddTime(int penaltyTime)   // penaltyTime is in seconds
    {
        int decimalDigits = (time % 1000);
        int secondDigits = ((time / 1000) % 100);
        int minuteDigits = (time / 100000);

        secondDigits += penaltyTime;
        minuteDigits += (int)(secondDigits / 60);
        secondDigits = secondDigits % 60;

        timerText = string.Format("{0:00}{1:00}{2:000}", minuteDigits, secondDigits, decimalDigits);

        PrintTime(timerText);
    }

    IEnumerator Count()
    {
        int start = 0;
        int step = time / scrollTimeFrames;

        UIEvents.current.TimeCount();
        do
        {
            PrintTime(string.Format("{0:0000000}", start));

            start += step;

            yield return new WaitForFixedUpdate();
        } while (start < time && isIncrementing);

        PrintTime(string.Format("{0:0000000}", time));

        if (this.tag == "RecordTime")
        {
            UIEvents.current.CurrentTime();
        }
        else if (this.tag == "CurrentTime")
        {
            int heartFrames = 0;

            while (heartFrames < healthLost)
            {
                int i = 0;
                do
                {
                    i += 1;

                    yield return new WaitForFixedUpdate();
                } while (i < 30 && isIncrementing);

                heartFrames++;
                AddTime(10 * heartFrames);

                UIEvents.current.CountHeartLost();
            }
        }
    }
}
