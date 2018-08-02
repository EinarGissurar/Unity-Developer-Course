using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip destroyed;
    [SerializeField] GameObject particles;
    [SerializeField] Sprite[] hitSprites;

    LevelManager level;
    GameStatus status;
    private int timesHit = 0, maxHits;

    private void Start() {
        maxHits = hitSprites.Length + 1;
        level = FindObjectOfType<LevelManager>();
        status = FindObjectOfType<GameStatus>();

        if (tag == "BreakableBlock") {
            level.AddBreakableBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "BreakableBlock") {
            timesHit++;
            if (timesHit >= maxHits) {
                DestroyBlock();
            }
            else {
                ShowNextHitSprite();
            }
        }
    }

    private void DestroyBlock() {
        AudioSource.PlayClipAtPoint(destroyed, Camera.main.transform.position);
        level.RemoveBreakableBlock();
        status.AddScore(maxHits);
        TriggerSparkles();
        Destroy(gameObject);
    }

    private void ShowNextHitSprite() {
        if (hitSprites[timesHit - 1] != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        }
        else {
            Debug.Log("You done goofed! - Block sprite is missing from array. - " + gameObject.name);
        }
    }

    private void TriggerSparkles() {
        GameObject pretties = Instantiate(particles, transform.position, transform.rotation);
        Destroy(pretties, 2f);
    }
}
