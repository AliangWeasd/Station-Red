using UnityEngine;
using System.Collections;

public class AngleLock : MonoBehaviour {

	public float angle = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion reverse = Quaternion.Euler(0,0,angle);
		transform.rotation = reverse;

	}
}
