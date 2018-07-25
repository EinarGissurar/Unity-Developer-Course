using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RocketController : MonoBehaviour {

    [SerializeField] float rotationSpeed = 5;
    [SerializeField] float thrust = 5;

    private Rigidbody rigidBody;
    private AudioSource rocketSound;

    enum State { Alive, Dying, Transcending}
    State state = State.Alive;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (state != State.Dying) {
            Thrust();
            Rotate();
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
                state = State.Transcending;
                Invoke("LoadNextScene", 1f);
                break;
            case "Obstacle":
                KillPlayer();
                break;
            default:
                KillPlayer();
                break;
        }
    }

    private void KillPlayer() {
        state = State.Dying;
        rocketSound.Stop();
        Invoke("Restart", 1f);
    }

    private void LoadNextScene() {
        SceneManager.LoadScene(1);
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
                rocketSound.Play();
            }
        }
        else if (rocketSound.isPlaying) {
            rocketSound.Stop();
        }
    }
}
