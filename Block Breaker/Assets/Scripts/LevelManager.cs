using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    private int nrOfBlocks = 0;
    private SceneLoader loader;

    private void Start() {
        loader = FindObjectOfType<SceneLoader>();
    }

    public void AddBreakableBlock() {
        nrOfBlocks++;
    }

    public void RemoveBreakableBlock() {
        nrOfBlocks--;
        if (nrOfBlocks <= 0) {
            loader.LoadNextScene();
        }
    }
}
