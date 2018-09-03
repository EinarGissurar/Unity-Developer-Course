using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {
    [SerializeField] float speed = 10f, laserSpeed = 10f, projectileFiringPeriod = 1f, padding = 1f;
    [SerializeField] GameObject playerLaser;

    private float deltaX, deltaY, newXPos, newYPos, xMin, xMax, yMin, yMax;
    private Coroutine firingRoutine;

	// Use this for initialization
	void Start () {
        setBoundary();
	}

    

    // Update is called once per frame
    void Update () {
        FireLaser();
        MoveAround();
	}

    private void FireLaser() {
        if (Input.GetButtonDown("Fire1")) {
            firingRoutine = StartCoroutine(ContinueFiring());
        }
        if (Input.GetButtonUp("Fire1")) {
            StopCoroutine(firingRoutine);
        }
    }

    IEnumerator ContinueFiring() {
        while(Input.GetButton("Fire1")) { 
            GameObject laser = Instantiate(playerLaser, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = Vector2.up * laserSpeed;
            yield return new WaitForSeconds(projectileFiringPeriod);
        }
    }
    
    private void MoveAround() {
        deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        deltaY = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }

    private void setBoundary() {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }
}
