using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip destroyed;
    [SerializeField] GameObject particles;

    LevelManager level;
    GameStatus status;

    private void Start() {
        level = FindObjectOfType<LevelManager>();
        status = FindObjectOfType<GameStatus>();
        level.AddBreakableBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        AudioSource.PlayClipAtPoint(destroyed, Camera.main.transform.position);
        level.RemoveBreakableBlock();
        status.AddScore();
        TriggerSparkles();
        Destroy(gameObject);
    }

    private void TriggerSparkles() {
        GameObject pretties = Instantiate(particles, transform.position, transform.rotation);
        Destroy(pretties, 2f);
    }
}
