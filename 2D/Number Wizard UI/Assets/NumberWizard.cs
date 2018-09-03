using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberWizard : MonoBehaviour {

	int max, min, guess;

	public int maxGuesses;
	public Text text;

	// Use this for initialization
	void Start() {
		StartGame();
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			GuessHigher();
		}

		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			GuessLower();
		}
	}

	public void GuessHigher() {
		min = guess;
		NextGuess();
	}

	public void GuessLower() {
		max = guess;
		NextGuess();
	}

	void StartGame() {
		min = 1;
		max = 1000;
		maxGuesses = 10;
		NextGuess();
	}

	void NextGuess() {
		maxGuesses--;
		if (maxGuesses <= 0) {
			Application.LoadLevel("Win");
		} else {
			Guess();
		}
	}

	void Guess() {
		guess = Random.Range(min,max+1);
		text.text = "Is it... " + guess + "?";
	}
}
