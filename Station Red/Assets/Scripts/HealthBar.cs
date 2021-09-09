using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int amount = 0;
    public int currentAmount;

    private Slider healthbar;

    // Start is called before the first frame update
    void Start()
    {
        healthbar = GetComponent<Slider>();

        if (healthbar == null)
        {
            throw new Exception("Slider component required to use this script.");
        }

        GameEvents.current.onPlayerAttacked += PlayerAttacked;
    }

    void OnDestroy()
    {
        GameEvents.current.onPlayerAttacked -= PlayerAttacked;
    }

    public void GainHeart()
    {
        if (currentAmount < amount)
        {
            currentAmount++;
            healthbar.value = currentAmount;
        }
    }

    public void LoseHeart()
    {
        if (currentAmount > 0)
        {
            currentAmount--;
            healthbar.value = currentAmount;
        }
    }

    public int GetAmount()
    {
        return currentAmount;
    }

    public void PlayerAttacked()
    {
        if (currentAmount > 0)
        {
            LoseHeart();
        }
        
        if(currentAmount == 0)
        {
            GameEvents.current.PlayerDeath();
        }
    }
}
