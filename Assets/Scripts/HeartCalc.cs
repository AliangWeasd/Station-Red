using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartCalc : MonoBehaviour
{
    public int heartsLeft;

    private Slider healthbar;

    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Slider>();

        if (healthbar == null)
        {
            throw new Exception("Slider component required to use this script.");
        }

        UIEvents.current.onCountHeartLost += CountHeartLost;
    }

    void OnDestroy()
    {
        UIEvents.current.onCountHeartLost -= CountHeartLost;
    }

    private void CountHeartLost()
    {
        heartsLeft--;
        healthbar.value = heartsLeft;
    }
}
