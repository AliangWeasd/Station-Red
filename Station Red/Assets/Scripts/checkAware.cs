using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class checkAware : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        Vector2 sight = collider.transform.position - transform.position;
        float magnitude = sight.magnitude;

        int mask = LayerMask.GetMask("Enemy", "Walls");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, sight.normalized, magnitude, mask);

        if (hit.collider != null)
        {
            magnitude = Vector3.Distance(transform.position, hit.collider.transform.position);
            Debug.DrawRay(transform.position, sight.normalized * magnitude, Color.white);
            if (hit.collider.gameObject.CompareTag("Enemy (Sight)"))
            {
                hit.collider.gameObject.GetComponent<patrolBehavior>().enabled = false;
                hit.collider.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                hit.collider.gameObject.GetComponent<ChargeAttack>().enabled = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Unlocked")
        {
            GetComponentInParent<Underneath>().enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Unlocked")
        {
            GetComponentInParent<Underneath>().enabled = false;
        }
    }
}
