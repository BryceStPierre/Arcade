using UnityEngine;
using System.Collections;

public class BowlBall : MonoBehaviour {

	public GameObject arrow;
	private Rigidbody ball;
	private bool fired;

	public float shotForce = 900f;
	public float moveSpeed = 10f;

	void Start () {
		ball = gameObject.GetComponent<Rigidbody>();
		fired = false;
	}
	
	void Update ()
	{
		float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
		if (Input.GetKey (KeyCode.LeftShift))
			transform.position = new Vector3 (Mathf.Clamp (transform.position.x + h, -2.7f, 2.7f), 1f, transform.position.z);
		else
			transform.Rotate (new Vector3 (0, h, 0));

		if (Input.GetButton("Fire1")) {
			if (arrow.transform.localScale.z < 3.2)
				arrow.transform.localScale += new Vector3(0, 0, 0.02f);
			if (arrow.transform.position.z < -11.6)
				arrow.transform.position += new Vector3(0, 0, 0.02f);
			if (shotForce < 1350f)
				shotForce += 10f;
		}
		if (Input.GetButtonUp("Fire1") && !fired) {
			Destroy(arrow);
			ball.AddForce(transform.forward * shotForce, ForceMode.Acceleration);
			fired = true;
			Invoke("failCase", 7f);
		}
	}

	void failCase () {
		BowlingManager.instance.throwIsDone();
		Destroy(gameObject);
	}

}