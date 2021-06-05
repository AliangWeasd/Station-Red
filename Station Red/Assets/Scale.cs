using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale : MonoBehaviour
{
    public float scaleFactor = 10.0f;
    private Vector3 scale = new Vector3(10, 0, 10);
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInParent<Camera>();
        transform.localScale = scale * cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = scale * cam.orthographicSize;
    }
}
