using UnityEngine;
using System.Collections;

public class slipperyWASD : MonoBehaviour {

	public string hort;
	public string vert;
	public int force;
	Rigidbody2D rb;

    public bool isOn = false;

	void Start () {
        GameEvents.current.onStartGamePoint += StartGamePoint;
        GameEvents.current.onPlayerDeath += PlayerDeath;

        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        if (isOn)
        {
            if (Input.GetButton(hort))
            {
                if (Input.GetAxis(hort) > 0)
                    rb.AddForce(Vector2.right * force, ForceMode2D.Force);
                else
                    rb.AddForce(Vector2.left * force, ForceMode2D.Force);
            }
            if (Input.GetButton(vert))
            {
                if (Input.GetAxis(vert) > 0)
                    rb.AddForce(Vector2.up * force, ForceMode2D.Force);
                else
                    rb.AddForce(Vector2.down * force, ForceMode2D.Force);
            }
        }
	}

    public void StartGamePoint()
    {
        isOn = true;
    }

    public void PlayerDeath()
    {
        isOn = false;
    }
}
