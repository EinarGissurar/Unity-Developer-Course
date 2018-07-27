using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField] Vector3 movementVector = new Vector3(10f, 0f, 0f);
    [SerializeField] float period = 2f;

    private Vector3 startingPosition, offset;
    private const float tau = Mathf.PI * 2;
    private float movementFactor, cycles, rawSineWave;

    // Use this for initialization
    void Start () {
        startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (period <= Mathf.Epsilon) {
            return;
        }
        cycles = Time.time / period;
        rawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = (rawSineWave / 2f) + 0.5f;

        offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
	}
}
