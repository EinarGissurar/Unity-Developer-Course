using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenUnitWith = 16f;

    float mousePosX;
    Vector2 paddlePos;

    // Update is called once per frame
    void Update () {
        mousePosX = Mathf.Clamp(Input.mousePosition.x / Screen.width * screenUnitWith, minX, maxX);
        paddlePos = new Vector2(mousePosX, transform.position.y);
        transform.position = paddlePos;
	}
}