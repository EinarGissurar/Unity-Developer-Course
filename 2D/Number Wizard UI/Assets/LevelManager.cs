using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	public void LoadLevel (string name) {
		Application.LoadLevel(name);
		Debug.Log("Level load " + name);
	}

	public void QuitRequest () {
		Debug.Log("I quit!");
		Application.Quit();
	}
}
