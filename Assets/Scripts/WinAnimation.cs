using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        float tiltAroundZ = 0;
        float heightIncrement = 0;
        float rotIncrement = 5;
        float heightInc = 0.005f;
        float rotInc = 0.05f;
        Vector3 scaleChange = new Vector3(1, 1, 1);
        float scaleInc = 1.01f;
        int timer = 200;
        int i = 0;

        while (i < timer)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + heightIncrement, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, tiltAroundZ);

            transform.localScale = scaleChange;

            tiltAroundZ -= rotIncrement;
            
            rotIncrement += rotInc;
            heightIncrement += heightInc;
            scaleChange *= scaleInc;

            i++;
            yield return new WaitForEndOfFrame();
        }
    }
}
