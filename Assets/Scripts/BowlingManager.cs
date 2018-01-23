using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BowlingManager : MonoBehaviour {

	public static BowlingManager instance = null;

	public GameObject ballPrefab;
	public GameObject pinsPrefab;
	public Transform ballPos;
	public Transform pinPos;
	public GameObject cloneBall;
	private GameObject clonePins;
	public GameObject gameOverMessage;

	public Text[] leftPoints;
	public Text[] rightPoints;
	public Text[] totalPoints;
	public Text last1;
	public Text last2;
	public Text last3;

	public bool doneThrow = false;
	private bool wasSpare = false;
	private bool wasStrike = false;

	private int roundPoints = 0;
	private int gamePoints = 0;
	private int pinCount = 0;

	private int throwNumber = 1;
	private int remaining = 0;
	private int round = 0;
	
	void Awake () { 
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		
		setUpPins ();
		setUpBall ();
	}

	void setUpPins () {
		Debug.Log ("setUpPins!");
		if (clonePins != null)
			Destroy (clonePins);
		clonePins = Instantiate (pinsPrefab, pinPos.position, pinPos.rotation) as GameObject;
	}

	void setUpBall () {
		Debug.Log ("setUpBall!");
		doneThrow = false;
		cloneBall = Instantiate (ballPrefab, ballPos.position, ballPos.rotation) as GameObject;
	}

	public void throwIsDone () {
		Debug.Log ("throwIsDone!");
		doneThrow = true;
		Destroy (cloneBall);

		if (round == 9)
			roundTen ();
		else
			roundN ();

		pinCount = 0;
		Invoke ("setUpBall", 2f);
	}

	void roundN () {
		if (throwNumber == 1) {
			remaining = 10 - pinCount;
			if (remaining == 0) {
				rightPoints[round].text = "X";
				roundPoints = 15;
				roundIsDone ();
			} 
			else {
				leftPoints[round].text = "" + pinCount;
				roundPoints = pinCount;
				throwNumber++;
			}
			if (wasSpare) {
				roundPoints += pinCount;
				wasSpare = false;
			}
		} else {
			if (pinCount == remaining) {
				rightPoints[round].text = "/";
				wasSpare = true;
			} 
			else
				rightPoints[round].text = "" + pinCount;
			roundPoints += pinCount;
			throwNumber = 1;
			roundIsDone ();
		}
	}

	void roundTen() {
		Debug.Log ("Round 10!");
		if (throwNumber == 1) {
			remaining = 10 - pinCount;
			if (remaining == 0) {
				last1.text = "X";
				roundPoints = 15;
				wasStrike = true;
				Invoke ("setUpPins", 2f);
			} else {
				last1.text = "" + pinCount;
				roundPoints = pinCount;
			}
			if (wasSpare) {
				roundPoints += pinCount;
				wasSpare = false;
			}
			throwNumber++;
		} 
		else if (throwNumber == 2) {
			if (pinCount == remaining) {
				last2.text = "/";
				roundPoints += pinCount;
				wasSpare = true;
				throwNumber++;
				Invoke ("setUpPins", 2f);
			}
			else if (wasStrike) {
				remaining = 10 - pinCount;
				if (remaining == 0) {
					last2.text = "X";
					roundPoints += 15;
					wasStrike = true;
					Invoke ("setUpPins", 2f);
				}
				else {
					last2.text = "" + pinCount;
					roundPoints += pinCount;
					wasStrike = false;
				}
				throwNumber++;
			}
			else
				roundIsDone ();
		} 
		else if (throwNumber == 3) {
			if (wasStrike) {
				if (pinCount == 10) {
					last3.text = "X";
					roundPoints += 15;
				}
				else {
					last3.text = "" + pinCount;
					roundPoints += pinCount;
				}
			}
			else if (pinCount == remaining) {
				last3.text = "/";
				roundPoints += pinCount;
				wasSpare = true;
				throwNumber++;
			}
			else {
				last3.text = "" + pinCount;
				roundPoints += pinCount;
			}
			roundIsDone ();
		}

	}

	void roundIsDone () {
		Debug.Log ("roundIsDone!");
		if (round != 9)
			Invoke ("setUpPins", 2f);
		gamePoints += roundPoints;
		totalPoints[round].text = "" + gamePoints;
		round++;
		checkGameOver ();
	}
	
	public void pinDown () {
		pinCount++;
	}

	void checkGameOver () {
		if (round == 10) {
			gameOverMessage.SetActive (true);
			Invoke ("gameOver", 2f);
		}
	}

	void gameOver () {
		Debug.Log ("Game over.");
		Application.LoadLevel (0);
	}

}