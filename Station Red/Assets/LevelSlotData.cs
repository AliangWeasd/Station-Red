using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlotData : MonoBehaviour
{
    public Sprite[] levelPictures;
    public Sprite defaultPicture;

    public Sprite getPicture(int index)
    {
        Sprite picture = defaultPicture;

        if (index >= 0 && index < levelPictures.Length)
        {
            picture = levelPictures[index];
        }

        return picture;
    }

    public int getLength()
    {
        return levelPictures.Length;
    }
}
