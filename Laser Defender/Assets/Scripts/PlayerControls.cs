using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    [SerializeField] float speed = 10f;
    [SerializeField] float padding = 1f;

    private float deltaX, deltaY, newXPos, newYPos, xMin, xMax, yMin, yMax;


	// Use this for initialization
	void Start () {
        setBoundary();
	}

    private void setBoundary() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

    // Update is called once per frame
    void Update () {
        MoveAround();
	}

    private void MoveAround() {

        deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);


        transform.position = new Vector2(newXPos, newYPos);
    }
}
