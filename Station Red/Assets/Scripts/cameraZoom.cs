using UnityEngine;
using System.Collections;

public class cameraZoom : MonoBehaviour {

	private Camera cam;
	public float zoom = 0.5f;
    public float max = 15.5f;
    public float min = 8.5f;

	// Use this for initialization
	void Start () {
		cam = GetComponent<Camera>();
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") > 0 && cam.orthographicSize < max)
        {
            cam.orthographicSize += zoom;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0 && cam.orthographicSize > min)
        {
            cam.orthographicSize -= zoom;
        }
	}
}
