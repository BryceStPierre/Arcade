using UnityEngine;
using System.Collections;

public class ThrowBall : MonoBehaviour {

	public Rigidbody projectile;
	public Transform shotPos;
	public float shotForce = 1000f;
	public float moveSpeed = 10f;
	
	void Update ()
	{
		if(Input.GetButtonUp("Fire1"))
		{
			Rigidbody shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
			shot.AddForce(shotPos.forward * shotForce, ForceMode.Acceleration);
		}
	}
}