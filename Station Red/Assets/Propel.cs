using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propel : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(t.up * speed, ForceMode2D.Force);
    }
}
