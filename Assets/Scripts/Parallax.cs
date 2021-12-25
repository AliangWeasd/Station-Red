using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour 
{
	private CanvasRenderer cr;
	private Material crMat;
	private Vector2 matOffset = new Vector2();

	public float parallax = 1000f;

	// Use this for initialization
	void Start () {
		cr = GetComponent<CanvasRenderer>();
		
		if (cr == null)
		{
			throw new Exception("CanvasRenderer component required to use this script.");
		}

		if(parallax == 0)
        {
			throw new Exception("Parallax cannot work with a parallax of 0.");
        }

		crMat = cr.GetMaterial();
	}
	
	// Update is called once per frame
	void Update () {
		crMat = cr.GetMaterial();

		if (crMat != null)
		{
			matOffset.x = transform.position.x / (transform.localScale.x * parallax);
			matOffset.y = transform.position.y / (transform.localScale.y * parallax);

			crMat.mainTextureOffset = matOffset;
		}
	}
}
