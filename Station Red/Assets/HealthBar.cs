using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int amount = 0;
    public int currentAmount;

    public Image[] hearts;
    public Sprite heart;
    public Sprite noHeart;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onPlayerAttacked += PlayerAttacked;

        currentAmount = amount;

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < amount) { 
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }
    }

    public void GainHeart()
    {
        if (currentAmount < amount)
        {
            currentAmount++;
            hearts[currentAmount - 1].enabled = true;
        }
    }

    public void LoseHeart()
    {
        if (currentAmount > 0)
        {
            hearts[currentAmount - 1].enabled = false;
            currentAmount--;
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
            hearts[currentAmount - 1].enabled = false;
            currentAmount--;
        }
        
        if(currentAmount == 0)
        {
            GameEvents.current.PlayerDeath();
        }
    }
}
