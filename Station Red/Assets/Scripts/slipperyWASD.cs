using UnityEngine;
using System.Collections;

public class slipperyWASD : MonoBehaviour {

	public string hort;
	public string vert;
	public int force;
	Rigidbody2D rb;

    public bool isOn = false;
    /*
	void OnEnable() 
    {
        GameEvents.current.onStartGamePoint += StartGamePoint;
        GameEvents.current.onPlayerDeath += PlayerDeath;
	}*/

    void Start()
    {
        GameEvents.current.onStartGamePoint += StartGamePoint;
        GameEvents.current.onPlayerDeath += PlayerDeath;

        rb = GetComponent<Rigidbody2D>();
    }

    void OnDestroy()
    {
        GameEvents.current.onStartGamePoint -= StartGamePoint;
        GameEvents.current.onPlayerDeath -= PlayerDeath;
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

        /*
        if (isOn)
        {
            if (Input.GetButton(hort))
            {
                h_speed = Input.GetAxis(hort) > 0 ? (h_speed + accel) : (h_speed - accel);
            }
            if (Input.GetButton(vert))
            {
                v_speed = Input.GetAxis(vert) > 0 ? (v_speed + accel) : (v_speed - accel);
            }
        }

        if (h_speed > 1)
            h_speed = 1;
        if (v_speed > 1)
            v_speed = 1;

        if ((h_speed * h_speed) < cutoff_speed_squared)
            h_speed = 0;
        if ((v_speed * v_speed) < cutoff_speed_squared)
            v_speed = 0;

        float angle = Mathf.Atan2(v_speed, h_speed);

        Debug.Log(angle);

        Vector3 pos = this.transform.position;
        pos.x += Mathf.Cos(angle) * h_speed * max_speed;
        pos.y += Mathf.Sin(angle) * v_speed * max_speed;
        this.transform.position = pos;

        h_speed = h_speed * friction;
        v_speed = v_speed * friction;
        */
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
