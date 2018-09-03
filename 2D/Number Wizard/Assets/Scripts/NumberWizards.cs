using UnityEngine;
using System.Collections;

public class NumberWizards : MonoBehaviour {

	int max, min, guess;

	// Use this for initialization
	void Start () {
		StartGame();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			min = guess;
			Guess();
		}

		else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			max = guess;
			Guess();
		}

		else if (Input.GetKeyDown(KeyCode.Return)) {
			print ("Hoorah!");
			StartGame();
		}
	}

	void StartGame () {
		min = 1;
		max = 1000;
		print("==========================");
		print("Welcome to Number Wizard");
		print("Pick a number between " + min + " and " + max + " but don't tell me.");
		Guess();
		max++;
	}

	void Guess () {
		guess = (max + min) / 2;
		print("Is it " + guess + "?");
		print("Press Up for Higher, Down for lower and Enter for correct guess.");
	}
}
