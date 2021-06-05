using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockTimer : MonoBehaviour
{
    public int scrollTimeFrames = 60;
    public Text timerText;
    public Image[] timer;
    public Sprite[] number;

    private float startTime;
    public bool isCounting = false;
    public bool isTimer = false;
    private int decimalDigits = 0;
    private int secondDigits = 0;
    private int minuteDigits = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onWinStateReached += WinStateReached;
        GameEvents.current.onPlayerDeath += PlayerDeath;
        GameEvents.current.onStartGamePoint += StartGamePoint;
    }

    public void StartGamePoint()
    {
        timerText.text = "0000000";
        startTime = Time.time;
        PrintTime(timerText.text);
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

        timerText.text = string.Format("{0:00}{1:00}{2:000}", minuteDigits, secondDigits, decimalDigits);

        PrintTime(timerText.text);
    }

    void PrintTime(string time)
    {
        for(int i = 0; i < time.Length; i++)
        {
            char digit = time[i];

            timer[i].sprite = number[digit - '0'];
        }
    }

    void AddTime(int penaltyTime)
    {
        secondDigits += penaltyTime;
        minuteDigits += (int)(secondDigits / 60);
        secondDigits = secondDigits % 60;

        timerText.text = string.Format("{0:00}{1:00}{2:000}", minuteDigits, secondDigits, decimalDigits);

        PrintTime(timerText.text);
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

        timerText.text = string.Format("{0:0000000}", time);
        PrintTime(string.Format("{0:0000000}", time));
    }

    IEnumerator CountInstant(int time)
    {
        timerText.text = string.Format("{0:0000000}", time);
        string timeString = string.Format("{0:0000000}", time);
        PrintTime(timeString);
        yield return null;
    }
}
