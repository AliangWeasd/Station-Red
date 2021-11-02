using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonPressed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SR_MenuEvents.current.onPlayPressed += PlayPressed;
        SR_MenuEvents.current.onBackPressed += BackPressed;
    }

    public void PlayPressed()
    {
        Debug.Log(transform.parent.transform.position);// StartCoroutine(Launch());
    }

    public void BackPressed()
    {
        Debug.Log(transform.parent.transform.position);//StartCoroutine(Hide());
    }
}
