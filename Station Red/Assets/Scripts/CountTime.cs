using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
    public int scrollTimeFrames = 60;

    private int time = 0;   // time is in milliseconds.
    private string timerText = "0000000";

    public Image[] timer;
    public Sprite[] number;

    private bool isIncrementing = true;
    private int healthLost = 0;

    void Start()
    {
        UIEvents.current.onStartRecordCount += StartRecordCount;
        UIEvents.current.onStartCurrentCount += StartCurrentCount;
        UIEvents.current.onRecordTime += RecordTime;
        UIEvents.current.onCurrentTime += CurrentTime;
        UIEvents.current.onStopTimeCount += StopTimeCount;

        GameEvents.current.onPlayerAttacked += PlayerAttacked;
    }

    void OnDestroy()
    {
        UIEvents.current.onStartRecordCount -= StartRecordCount;
        UIEvents.current.onStartCurrentCount -= StartCurrentCount;
        UIEvents.current.onRecordTime -= RecordTime;
        UIEvents.current.onCurrentTime -= CurrentTime;
        UIEvents.current.onStopTimeCount -= StopTimeCount;

        GameEvents.current.onPlayerAttacked -= PlayerAttacked;
    }

    private void StartRecordCount(int time)
    {
        if(this.tag == "RecordTime")
        {
            this.time = time;
        }
    }

    private void StartCurrentCount(int time)
    {
        if (this.tag == "CurrentTime")
        {
            this.time = time;
        }
    }

    private void RecordTime()
    {
        if(this.tag == "RecordTime")
        {
            StartCoroutine(Count());
        }
    }

    private void CurrentTime()
    {
        if (this.tag == "CurrentTime")
        {
            StartCoroutine(Count());
        }
    }

    private void StopTimeCount()
    {
        isIncrementing = false;
    }

    public void PlayerAttacked()
    {
        healthLost++;
    }

    void PrintTime(string time)
    {
        for (int i = 0; i < time.Length; i++)
        {
            char digit = time[i];

            timer[i].sprite = number[digit - '0'];
        }
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

        if(this.tag == "RecordTime")
        {
            UIEvents.current.CurrentTime();
        }
        else if(this.tag == "CurrentTime")
        {
            int heartFrames = 0;

            while(heartFrames < healthLost) {
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
