using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour {

    [SerializeField] float rotationSpeed = 5f, thrust = 5f, loadDelay = 2f;
    [SerializeField] AudioClip mainEngine, death, victory;
    [SerializeField] ParticleSystem pEngine, pDeath, pVictory;
    [SerializeField] bool debugMode = false;

    private Rigidbody rigidBody;
    private AudioSource rocketSound;
    private bool collisionToggle = true;
    private int levelIndex, nextLevelIndex;

    enum State { Alive, Dying, Transcending}
    State state = State.Alive;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (state == State.Alive) {
            Thrust();
            Rotate();
            if (debugMode) {
                DebugMode();
            }
        }
    }

    private void DebugMode() {
        if (Input.GetKeyDown(KeyCode.L)) {
            TransitionPlayer();
        }
        if (Input.GetKeyDown(KeyCode.C)) {
            if (collisionToggle) {
                collisionToggle = false;
            }
            else {
                collisionToggle = true;
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (state != State.Alive) {
            return;
        }
        switch (collision.gameObject.tag) { 
            case "Friendly":
                break;
            case "Goal":
                TransitionPlayer();
                break;
            case "Obstacle":
                if (collisionToggle) {
                KillPlayer();
                }
                break;
            default:
                if (collisionToggle) {
                KillPlayer();
                }
                break;
        }
    }

    private void TransitionPlayer() {
        state = State.Transcending;
        if (rocketSound.isPlaying) {
            rocketSound.Stop();
        }
        rocketSound.PlayOneShot(victory);
        pVictory.Play();
        Invoke("LoadNextScene", loadDelay);
    }

    private void KillPlayer() {
        state = State.Dying;
        if (rocketSound.isPlaying) {
            rocketSound.Stop();
        }
        rocketSound.PlayOneShot(death);
        pDeath.Play();

        Invoke("Restart", loadDelay);
    }

    private void LoadNextScene() {
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        if (levelIndex == SceneManager.sceneCountInBuildSettings - 1) {
            nextLevelIndex = 0;
        }
        else {
            nextLevelIndex = levelIndex + 1;
        }
        SceneManager.LoadScene(nextLevelIndex);
    }

    private void Restart() {
        SceneManager.LoadScene(0);
    }

    private void Rotate() {
        rigidBody.freezeRotation = true;
        if (Input.GetKey(KeyCode.A) && !(Input.GetKey(KeyCode.D))) {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D) && !(Input.GetKey(KeyCode.A))) {
            transform.Rotate(-Vector3.forward * Time.deltaTime * rotationSpeed);
        }
        rigidBody.freezeRotation = false;
    }

    private void Thrust() {
        if (Input.GetKey(KeyCode.Space)) {
            rigidBody.AddRelativeForce(Vector3.up * Time.deltaTime * thrust);
            if (!rocketSound.isPlaying) {
                rocketSound.PlayOneShot(mainEngine);
            }
            pEngine.Play();
        }
        else if (rocketSound.isPlaying) {
            rocketSound.Stop();
        }
        else if (pEngine.isPlaying) {
            pEngine.Stop();
        }
    }
}
