using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockingBehavior : MonoBehaviour
{
    private float AmountOfKeys = 0;
    /*
    void Awake()
    {
        GameEvents.current.onKeyCollected += KeyCollected;
    }*/

    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onKeyCollected += KeyCollected;

        AmountOfKeys = this.GetComponent<CreateKeys>().getPositionsLength();

        if (AmountOfKeys == 0)
        {
            UnlockDoor();
        }
    }

    void OnDestroy()
    {
        GameEvents.current.onKeyCollected -= KeyCollected;
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
