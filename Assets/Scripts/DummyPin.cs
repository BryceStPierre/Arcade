using UnityEngine;
using System.Collections;

public class DummyPin : MonoBehaviour {

	public AudioClip strike;
	private AudioSource source;

	private bool played = false;
	private int iter = 0;

	void Start () {
		source = GetComponent<AudioSource> ();		
	}
	
	void OnTriggerEnter (Collider c) {
		if (!played) {
			source.PlayOneShot (strike, 1f);
			if (iter == 0 || iter == 1)
				played = false;
			else
				played = true;
			iter++;
		}
	}

}