using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockingBehavior : MonoBehaviour
{
    private float AmountOfKeys = 0;

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onKeyCollected += KeyCollected;

        AmountOfKeys = transform.childCount;
        if (AmountOfKeys == 0)
        {
            UnlockDoor();
        }
    }

    public void KeyCollected()
    {
        AmountOfKeys--;
        if (AmountOfKeys == 0)
        {
            UnlockDoor();
        }
    }

    void UnlockDoor()
    {
        GameEvents.current.AllKeysCollected();
    }
}
