using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateKeys : MonoBehaviour
{
    public Vector2[] keyPositions;
    public GameObject key;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Vector2 position in keyPositions)
        {
            Instantiate(key, position, transform.rotation);
        }
    }

    public int getPositionsLength()
    {
        return keyPositions.Length;
    }
}
