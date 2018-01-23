using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public AudioClip strike;
	private AudioSource source;
	public ParticleSystem dust;
	private bool down = false;
	private bool played = false;
	private int iter = 0;

	void Start () {
		source = GetComponent<AudioSource> ();		
	}

	void OnTriggerEnter (Collider c) {
		if (c.gameObject.name != "BowlingBall(Clone)" && c.gameObject.name != "BowlingPin" &&
		    c.gameObject.name != "Pop" && !down) {
			down = true;
			Debug.Log ("Pin down!");
			BowlingManager.instance.pinDown();
			Invoke("pop", 0.5f);
		}
		if (!played) {
			source.PlayOneShot (strike, 1f);
			if (iter == 0 || iter == 1)
				played = false;
			else
				played = true;
			iter++;
		}
	}

	void pop () {
		dust.Play();
		Destroy(gameObject, 0.3f);
	}

}