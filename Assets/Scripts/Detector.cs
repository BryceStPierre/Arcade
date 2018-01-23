using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour {

	void OnCollisionEnter (Collision c) {
		if (c.gameObject.name == "BowlingBall(Clone)") {
			Debug.Log ("Detected, throw is done!");
			BowlingManager.instance.throwIsDone ();
		}
	}

}