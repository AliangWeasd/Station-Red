using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Player") {
			//collision.gameObject.GetComponent<healthBar> ().health--;
            Debug.Log("Hello, I am " + gameObject.name);
        }
	}
		
}
