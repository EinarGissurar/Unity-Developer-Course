using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {

    private WaveConfig currentWaveConfig;
    private List<Transform> waypoints;
    private int waypointIndex = 0;

    private Vector3 target;
    private float deltaSpeed;

	// Use this for initialization
	void Start () {
        waypoints = currentWaveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        MoveAlongOrDie();
	}

    public void SetWaveConfig(WaveConfig WaveConfig) {
        this.currentWaveConfig = WaveConfig;
    }

    private void MoveAlongOrDie() {
        if (waypointIndex < waypoints.Count) {
            target = waypoints[waypointIndex].transform.position;
            deltaSpeed = currentWaveConfig.GetMoveSpeed() * Time.deltaTime;
            if (transform.position == target) {
                waypointIndex++;
                Debug.Log("Current waypoint: " + waypointIndex);
                Debug.Log("Number of waypoints: " + waypoints.Count);
            }
            else {
                transform.position = Vector2.MoveTowards(transform.position, target, deltaSpeed);
            }
        }
        else {
            Debug.Log("Dead!");
            Destroy(gameObject);
        }
    }
}
