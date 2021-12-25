using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBackground : MonoBehaviour
{
    public GameObject background;

    private Camera cam;
    private Vector3 scale = new Vector3(1, 1, 1);

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        background.transform.localScale = scale * (cam.orthographicSize / 2);
    }
}
