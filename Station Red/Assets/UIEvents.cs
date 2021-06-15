using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents : MonoBehaviour
{
    public static UIEvents current;

    private void Awake()
    {
        if (current != null)
        {
            Destroy(gameObject);
        }
        else
        {
            current = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public event Action onTimeCount;
    public event Action onStopTimeCount;
    public event Action onCountHeartLost;
    public event Action<int> onStartRecordCount;
    public event Action<int> onStartCurrentCount;
    public event Action onRecordTime;
    public event Action onCurrentTime;
    public event Action onFailTime;

    public void TimeCount()
    {
        if (onTimeCount != null)
        {
            onTimeCount();
        }
    }

    public void StopTimeCount()
    {
        if (onStopTimeCount != null)
        {
            onStopTimeCount();
        }
    }

    public void CountHeartLost()
    {
        if (onCountHeartLost != null)
        {
            onCountHeartLost();
        }
    }

    public void StartRecordCount(int time)
    {
        if (onStartRecordCount != null)
        {
            onStartRecordCount(time);
        }

    }
    public void StartCurrentCount(int time)
    {
        if (onStartCurrentCount != null)
        {
            onStartCurrentCount(time);
        }
    }

    public void RecordTime()
    {
        if (onRecordTime != null)
        {
            onRecordTime();
        }
    }

    public void CurrentTime()
    {
        if (onCurrentTime != null)
        {
            onCurrentTime();
        }
    }

    public void FailTime()
    {
        if(onFailTime != null)
        {
            onFailTime();
        }
    }
}
