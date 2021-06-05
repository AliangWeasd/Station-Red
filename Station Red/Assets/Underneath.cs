using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underneath : MonoBehaviour
{
    int mask;
    public GameObject winAnimation;

    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Walls");
    }

    // Update is called once per frame
    void Update()
    {
        // It's just on the center.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(1,0), 0, mask);

        if (hit.collider != null)
        {
            //Debug.Log(hit.collider.gameObject.name);
            winAnimation.transform.position = transform.position;
            Instantiate(winAnimation);
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.SetActive(false);
            GameEvents.current.WinStateReached();
            //this.enabled = false;
        }
    }
}
