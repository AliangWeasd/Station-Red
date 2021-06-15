using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCalc : MonoBehaviour
{
    public int heartsLeft;

    // Start is called before the first frame update
    void Start()
    {
        UIEvents.current.onCountHeartLost += CountHeartLost;
    }

    void OnDestroy()
    {
        UIEvents.current.onCountHeartLost -= CountHeartLost;
    }

    private void CountHeartLost()
    {
        this.gameObject.transform.GetChild(heartsLeft - 1).gameObject.SetActive(false);
        heartsLeft--;
    }
}
