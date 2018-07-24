using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {

    [SerializeField] float rotationSpeed = 5;
    [SerializeField] float thrust = 5;

    private Rigidbody rigidBody;
    private AudioSource rocketSound;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        Thrust();
        Rotate();
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
