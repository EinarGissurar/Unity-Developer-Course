using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour {

    [Range(0.1f, 5.0f)]
    [SerializeField] float gameSpeed = 1.0f;
    [SerializeField] int BlockValue;
    [SerializeField] TextMeshProUGUI scoreDisplay;

    int currentScore = 0;

    private void Awake() {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1) {
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void RestartGame() {
        Destroy(gameObject);
    }

    private void Start() {
        scoreDisplay.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
	}

    public void AddScore(int multiplier) {
        currentScore += Mathf.CeilToInt(BlockValue * multiplier);
        scoreDisplay.text = currentScore.ToString();
    }
}
