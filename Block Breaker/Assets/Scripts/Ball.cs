using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball: MonoBehaviour {

    [SerializeField] Paddle paddle;
    [SerializeField] float vX = 2f; 
    [SerializeField] float vY = 15f;

    Vector2 paddleToBallV;

    bool start = false;

    // Use this for initialization
    void Start () {
        paddleToBallV = transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (!start)
        {
            handleStart();
        }
    }

    private void handleStart()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallV;
        if (Input.GetMouseButtonDown(0))
        {
            start = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(vX, vY);
        }
    }
}
