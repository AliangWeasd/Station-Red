using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public Sprite locked;
    public Sprite unlocked;

    private SpriteRenderer sr;

    void Start()
    {
        GameEvents.current.onAllKeysCollected += AllKeysCollected;

        sr = GetComponent<SpriteRenderer>();
        sr.sprite = locked;
    }

    public void AllKeysCollected()
    {
        sr.sprite = unlocked;
        gameObject.tag = "Unlocked";
    }
}
