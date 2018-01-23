using UnityEngine;
using System.Collections;

public class Tiling : MonoBehaviour {

	void Awake () {
		transform.GetComponent<Renderer>().material.mainTexture.wrapMode = TextureWrapMode.Repeat;
	}

}