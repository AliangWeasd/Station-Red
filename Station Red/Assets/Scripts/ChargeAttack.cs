using UnityEngine;
using System.Collections;

public class ChargeAttack : MonoBehaviour {
	public float speed = 5f;
	public GameObject target;
    public bool toggled = true;
	Rigidbody2D rb;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
    }

    void OnEnable()
    {
        Decide();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        if (toggled)
            rb.AddForce(transform.up * speed, ForceMode2D.Force);
	}

    void SetAngle()
    {
        Vector3 cPos = target.transform.position;
        Vector3 pos = transform.position;

        Vector3 direction = cPos - pos;
        float x = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
        if (x < 0)
            x = 360 + x;

        Quaternion angle = Quaternion.Euler(0, 0, x);

        transform.rotation = angle;
    }

    public void Decide()
    {
        Vector2 sight = target.transform.position - transform.position;
        float magnitude = sight.magnitude;

        int mask = LayerMask.GetMask("Player", "Walls");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, sight.normalized, magnitude, mask);

        if (hit.collider != null)
        {
            magnitude = Vector3.Distance(transform.position, hit.collider.transform.position);

            Debug.DrawLine(transform.position, hit.collider.transform.position);
            if (hit.collider.gameObject.tag == "Wall")
            {
                this.gameObject.GetComponent<patrolBehavior>().enabled = true;
                this.gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
                this.enabled = false;
            }
            else
            {
                SetAngle();
            }
        }
    }

    void OnCollisionEnter2D()
    {
        Decide();
    }
}
