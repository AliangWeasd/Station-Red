using UnityEngine;
using System;
using System.Collections;

public class PlayerDamage : MonoBehaviour {
	public Sprite deadSprite;
    public int invincibleTimer = 120;
    public int stunTimer = 30;
    public float knockback = 20f;
    private bool toggled = true;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    private bool isDead = false;
    /*
	void OnEnable() {
        GameEvents.current.onPlayerDeath += PlayerDeath;
	}*/

    void Start()
    {
        GameEvents.current.onPlayerDeath += PlayerDeath;

        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        if(sprite == null || rb == null)
        {
            throw new Exception("Sprite Renderer and RigidBody2D are required.");
        }
    }

    void OnDestroy()
    {
        GameEvents.current.onPlayerDeath -= PlayerDeath;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (toggled && (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy (Sight)")))
        {
            if (!isDead)
            {
                GameEvents.current.PlayerAttacked();
                toggled = false;
                StartCoroutine(InvincibleTimer());
            }

            rb.velocity = rb.velocity.normalized;
            rb.velocity *= knockback;
        }
    }

    IEnumerator InvincibleTimer()
    {
        int i = 0;

        int restOfTimer = invincibleTimer - stunTimer;

        if (!isDead)
        {
            gameObject.GetComponent<slipperyWASD>().enabled = false;
            while (i < stunTimer)
            {
                sprite.enabled = !sprite.enabled;

                i += 2;

                yield return new WaitForFixedUpdate();
                yield return new WaitForFixedUpdate();
            }

            gameObject.GetComponent<slipperyWASD>().enabled = true;

            i = 0;
            while (i < restOfTimer)
            {
                sprite.enabled = !sprite.enabled;

                i += 2;

                yield return new WaitForFixedUpdate();
                yield return new WaitForFixedUpdate();
            }


            toggled = true;
        }
    }

    public void PlayerDeath()
    {
        isDead = true;

        gameObject.GetComponent<SpriteRenderer>().sprite = deadSprite;
        gameObject.tag = "Wall";
        //gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
