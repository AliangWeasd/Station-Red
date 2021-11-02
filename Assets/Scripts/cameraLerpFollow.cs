using UnityEngine;
using System.Collections;

public class cameraLerpFollow : MonoBehaviour {
	public Transform target;
	public Transform chaser;
    private Vector3 lastKnown;
	public float speed = 1.0f;
	private float journeyLength;

	void Start () {
		GameEvents.current.onWinStateReached += WinStateReached;
		GameEvents.current.onPlayerDeath += FailStateReached;
	}

	public void WinStateReached()
	{
		target = null;
	}

	public void FailStateReached()
    {
		target = null;
    }

	void FixedUpdate () {
        if (target)
        {
            lastKnown = target.position;

			Vector3 posBubble = new Vector3(lastKnown.x, lastKnown.y, -10);
			Vector3 camLoc = new Vector3(chaser.transform.position.x, chaser.transform.position.y, -10);

			journeyLength = Vector3.Distance(posBubble, camLoc);
			float fracJourney = journeyLength / speed;
			transform.position = Vector3.Lerp(camLoc, posBubble, fracJourney);
		}
	}
}
