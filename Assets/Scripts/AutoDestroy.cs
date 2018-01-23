using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	void Start () {
		Destroy (gameObject, 3f);
	}

}
