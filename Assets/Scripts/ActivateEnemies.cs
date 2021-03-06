using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemies : MonoBehaviour
{ 
    void Start()
    {
        GameEvents.current.onStartGamePoint += StartGamePoint;
    }

    void OnDestroy()
    {
        GameEvents.current.onStartGamePoint -= StartGamePoint;
    }

    public void StartGamePoint()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<patrolBehavior>() != null)
            {
                transform.GetChild(i).GetComponent<patrolBehavior>().enabled = true;
            }
        }
    }
}
