using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetAttack : MonoBehaviour
{
    public float speed = 5f;
    public bool toggled = true;
    public GameObject target;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (toggled)
        {
            Vector3 cPos = target.transform.position;
            Vector3 pos = transform.position;

            Vector3 direction = cPos - pos;
            float x = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90);
            if (x < 0)
                x = 360 + x;

            Quaternion angle = Quaternion.Euler(0, 0, x);

            transform.rotation = angle;

            Vector3 targetDirection = target.transform.position - transform.position;
            targetDirection = Vector3.Normalize(targetDirection);
            rb.AddForce(transform.up * speed, ForceMode2D.Force);
        }
    }
}
