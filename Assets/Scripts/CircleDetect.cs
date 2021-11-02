using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// THIS ISN'T USEFUL. IT'S A POOR EDIT OF CHASE.CS
public class CircleDetect : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 sight = target.transform.position - transform.position;
        float magnitude = sight.magnitude;

        // Oh noooooooo I mistook tags for layers. UGGHHHH
        int mask = LayerMask.GetMask("Player", "Walls");

        //int mask = 1 << LayerMask.NameToLayer("Walls");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, sight.normalized, magnitude, mask);
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, sight.normalized, magnitude);

        if (hit.collider != null)
        {
            magnitude = Vector3.Distance(transform.position, hit.collider.transform.position);

            //Debug.DrawRay(transform.position, sight.normalized * magnitude, Color.white);
            Debug.DrawLine(transform.position, hit.collider.transform.position);
            //Debug.Log(hit.collider.gameObject.tag);
        }
    }
}
