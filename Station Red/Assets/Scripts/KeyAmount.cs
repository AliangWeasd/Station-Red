using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyAmount : MonoBehaviour
{
    public Text timerText;  // Not connected to Key List, only synchronized.
    public Image lockAmount;
    public Sprite[] number;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onKeyCollected += KeyCollected;
        
        PrintTime(timerText.text);
    }

    void OnDestroy()
    {
        GameEvents.current.onKeyCollected -= KeyCollected;
    }

    void PrintTime(string time)
    {
        // Should probably have a safety check here.
        char digit = time[0];
        lockAmount.sprite = number[digit - '0'];
    }

    public void KeyCollected()
    {
        timerText.text = ((char)(timerText.text[0] - 1)).ToString();
        PrintTime(timerText.text);
    }
}
