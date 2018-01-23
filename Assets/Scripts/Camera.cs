using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public Transform target;

	void Update () {

		if (BowlingManager.instance.cloneBall != null) {
			target = BowlingManager.instance.cloneBall.transform;
			transform.position = new Vector3 (target.position.x, transform.position.y, transform.position.z);
		}
		//if (!BowlingManager.instance.isDoneThrow())
		//	transform.LookAt(target);
		float h = Input.GetAxis("Horizontal") * Time.deltaTime * 10f;
		if (Input.GetKey (KeyCode.LeftShift))
			transform.position = new Vector3 (Mathf.Clamp (target.position.x + h, -2.7f, 2.7f), transform.position.y, transform.position.z);
	}

}