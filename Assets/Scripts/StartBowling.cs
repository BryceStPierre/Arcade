using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartBowling : MonoBehaviour {

	public GameObject startGameMessage;
	public string minigameName;
	public string minigameDesc;
	private bool inFront = false;
	public Text gameTitle;
	public Text gameDesc;
	
	void Update () {
		if (Input.GetKeyUp (KeyCode.E) && inFront) {
			gameTitle.text = minigameName;
			gameDesc.text = minigameDesc;
			startGameMessage.SetActive(false);
			GameManager.instance.startMinigame (minigameName);
		}
	}
	
	void OnTriggerEnter (Collider c) {
		inFront = true;
		Debug.Log ("Inside and ready.");
		startGameMessage.SetActive(true);
	}
	
	void OnTriggerExit (Collider c){
		inFront = false;
		Debug.Log ("Outside.");
		startGameMessage.SetActive(false);
	}

}