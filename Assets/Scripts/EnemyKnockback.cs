using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    public int stunTimer = 60;
    public float knockback = 10f;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(StunTimer());
            rb.velocity = rb.velocity.normalized;
            rb.velocity *= knockback;
        }
    }

    IEnumerator StunTimer()
    {
        int i = 0;

        gameObject.GetComponent<ChargeAttack>().toggled = false;
        while (i < stunTimer)
        {
            i++;
            yield return new WaitForFixedUpdate();
        }
        gameObject.GetComponent<ChargeAttack>().toggled = true;
        gameObject.GetComponent<ChargeAttack>().Decide();
    }
}
