using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroZoom : MonoBehaviour
{
    public AnimationCurve delta;
    public float startSize = 100f;
    public float endSize = 20f;
    public int timeInFrames = 120;

    public Vector3 destination = new Vector3();

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        GameEvents.current.StartingGame();

        StartCoroutine(ZoomIn());
    }

    // Update is called once per frame
    IEnumerator ZoomIn()
    {
        float sizeChange = startSize - endSize;
        Vector3 linearRoute = destination - transform.position;
        Vector3 deltaMove = linearRoute / timeInFrames;

        cam.orthographicSize = startSize;

        int i = 0;
        while(i < timeInFrames)
        {
            i++;

            Vector3 pos = transform.position;
            pos += deltaMove;
            transform.position = pos;

            float size = startSize + (-sizeChange * delta.Evaluate((float)i / timeInFrames));
            cam.orthographicSize = size;

            yield return new WaitForFixedUpdate();
        }

        transform.position = destination;
        cam.orthographicSize = endSize;

        cam.GetComponent<cameraZoom>().enabled = true;
        cam.GetComponent<cameraLerpFollow>().enabled = true;

        GameEvents.current.StartGamePoint();

        yield return null;
    }
}
