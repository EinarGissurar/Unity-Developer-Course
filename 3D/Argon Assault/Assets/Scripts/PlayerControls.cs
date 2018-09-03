using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    [SerializeField] float xSpeed = 5f;
    [SerializeField] float ySpeed = 5f;
    [SerializeField] float xScreenRange = 5f;
    [SerializeField] float yScreenRange = 4.5f;

    private float horizontalMovement;
    private float verticalMovement;
    private float deltaX, deltaY;
    private float localX, localY;

    // Update is called once per frame
    void Update () {
        horizontalMovement = Input.GetAxis("Horizontal");
        verticalMovement = Input.GetAxis("Vertical");

        deltaX = horizontalMovement * xSpeed * Time.deltaTime;
        deltaY = verticalMovement * ySpeed * Time.deltaTime;

        localX = Mathf.Clamp((deltaX + transform.localPosition.x), -xScreenRange, xScreenRange);
        localY = Mathf.Clamp((deltaY + transform.localPosition.y), -yScreenRange, yScreenRange);

        transform.localPosition = new Vector3(localX, localY, transform.localPosition.z);

        if (Input.GetButtonDown("Fire1")) {
            Debug.Log("Blem!");
        }
	}
}
