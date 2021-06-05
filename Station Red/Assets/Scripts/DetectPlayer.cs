using UnityEngine;
using System.Collections;

public class DetectPlayer : MonoBehaviour {
	public GameObject player;
	public Sprite angry;
	public bool detected;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (player == null) {
			GameObject search = GameObject.FindGameObjectWithTag ("Player");
			if (search != null)
				player = search;
		}
		if(player == null)
			return;
		
		Vector2 direction = player.transform.position - transform.position;
		float magnitude = Vector3.Distance (transform.position, player.transform.position);

		int mask = 1 << LayerMask.NameToLayer ("Terrain")
		         | 1 << LayerMask.NameToLayer ("Player");
		
		RaycastHit2D hit = Physics2D.Raycast (transform.position, direction,magnitude,mask);

		if (hit.collider != null) {
            Debug.Log(hit.collider.tag);

            if (hit.collider.tag == "Player" && !detected) {
				StartCoroutine (Surprise());
				detected = true;
			} else if(hit.collider.tag != "Player"){
				detected = false;
			}
		}
		//Debug.DrawRay (transform.position, direction);

        Vector2 left = Vector2.Perpendicular(direction);
        left.Normalize();
        left *= 2.3f;
        Vector2 right = direction - left;
        left += direction;

        Debug.DrawRay(transform.position, left);
        Debug.DrawRay(transform.position, right);
    }

	IEnumerator Surprise(){
		GetComponent<Animator> ().enabled = true;
		yield return new WaitForSeconds (0.68f);
		GetComponent<Animator> ().enabled = false;
		GetComponent<SpriteRenderer> ().sprite = angry;
		yield return null;
	}
}
