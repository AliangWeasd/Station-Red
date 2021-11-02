using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClockTimer : MonoBehaviour
{
    public int scrollTimeFrames = 60;
    public Image[] timer;
    public Sprite[] number;

    private float startTime;
    public bool isCounting = false;
    public bool isTimer = false;
    private int decimalDigits = 0;
    private int secondDigits = 0;
    private int minuteDigits = 0;

    private string timerText = "0000000";

    private TMP_Text UItext;

    // Start is called before the first frame update
    void Start()
    {
        UItext = GetComponent<TMP_Text>();

        if (UItext == null)
        {
            throw new Exception("TextMeshProUGUI component required to use this script.");
        }

        GameEvents.current.onWinStateReached += WinStateReached;
        GameEvents.current.onPlayerDeath += PlayerDeath;
        GameEvents.current.onStartGamePoint += StartGamePoint;
    }

    void OnDestroy()
    {
        GameEvents.current.onWinStateReached -= WinStateReached;
        GameEvents.current.onPlayerDeath -= PlayerDeath;
        GameEvents.current.onStartGamePoint -= StartGamePoint;
    }

    public void StartGamePoint()
    {
        startTime = Time.time;
        PrintTime(timerText);
        isCounting = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isCounting || !isTimer)
            return;

        float currentTime = Time.time - startTime;

        decimalDigits = (int)(currentTime % 1 * 1000);
        secondDigits = (int)(currentTime % 60);
        minuteDigits = (int)(currentTime / 60);

        timerText = string.Format("{0:00}{1:00}{2:000}", minuteDigits, secondDigits, decimalDigits);

        PrintTime(timerText);
    }

    void PrintTime(string time)
    {
        string timeWithColons = time.Insert(2, ":").Insert(5, ":");

        UItext.text = timeWithColons;
        UItext.text = "<mspace=0.6em>" + UItext.text + "</mspace>";
    }

    void AddTime(int penaltyTime)
    {
        secondDigits += penaltyTime;
        minuteDigits += (int)(secondDigits / 60);
        secondDigits = secondDigits % 60;

        timerText = string.Format("{0:00}{1:00}{2:000}", minuteDigits, secondDigits, decimalDigits);

        PrintTime(timerText);
    }

    public void SetTime(int dec, int sec, int min)
    {
        decimalDigits = dec;
        secondDigits = sec;
        minuteDigits = min;
    }

    public int GetDecimal() { return decimalDigits; }
    public int GetSecond() { return secondDigits; }
    public int GetMinute() { return minuteDigits; }

    public void WinStateReached()
    {
        /*
        foreach(Image character in timer)
        {
            character.color = Color.green;
        }
        */
        isCounting = false;
    }

    public void PlayerDeath()
    {
        isCounting = false;
    }

    IEnumerator Count(int time)
    {
        int start = 0;
        int step = time / scrollTimeFrames;

        do
        {
            string timeString = string.Format("{0:0000000}", start);
            PrintTime(timeString);

            start += step;

            yield return new WaitForEndOfFrame();
        } while (start < time);

        timerText = string.Format("{0:0000000}", time);
        PrintTime(string.Format("{0:0000000}", time));
    }

    IEnumerator CountInstant(int time)
    {
        timerText = string.Format("{0:0000000}", time);
        string timeString = string.Format("{0:0000000}", time);
        PrintTime(timeString);
        yield return null;
    }

    public string getTimerText()
    {
        return timerText;
    }
}
