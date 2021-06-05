using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCalc : MonoBehaviour
{
    public int heartsLeft;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimeCalc(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            this.gameObject.transform.GetChild(2 - i).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForEndOfFrame();
    }

    IEnumerator LoseHeart()
    {
        this.gameObject.transform.GetChild(heartsLeft - 1).gameObject.SetActive(false);
        heartsLeft--;
        yield return null;
    }

    IEnumerator TimeCalcInstant(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            this.gameObject.transform.GetChild(2 - i).gameObject.SetActive(false);
        }
        yield return null;
    }
}
