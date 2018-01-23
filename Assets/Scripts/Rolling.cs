using UnityEngine;
using System.Collections;

public class Rolling : MonoBehaviour {

	public AudioClip rolling;
	private AudioSource source;

	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter (Collider c) {
		source.PlayOneShot(rolling, 0.8f);
	}

}