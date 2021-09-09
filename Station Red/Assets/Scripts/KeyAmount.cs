using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyAmount : MonoBehaviour
{
    public int keyAmount;  // Not connected to Key List, only synchronized.
    public Image lockAmount;
    public Sprite[] number;

    private TMP_Text UItext;

    // Start is called before the first frame update
    void Start()
    {
        UItext = GetComponentInChildren<TMP_Text>();

        if (UItext == null)
        {
            throw new Exception("TextMeshProUGUI child component required to use this script.");
        }

        GameEvents.current.onKeyCollected += KeyCollected;

        PrintAmount(keyAmount);
    }

    void OnDestroy()
    {
        GameEvents.current.onKeyCollected -= KeyCollected;
    }

    void PrintAmount(int keysLeft)
    {
        UItext.text = "<mspace=0.6em>x" + keysLeft + "</mspace>";

        // Should probably have a safety check here.
        //char digit = keysLeft[0];
        //lockAmount.sprite = number[digit - '0'];
    }

    public void KeyCollected()
    {
        keyAmount--;
        PrintAmount(keyAmount);
    }
}
