using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig: ScriptableObject {

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f, spawnRandomFactor = 0.3f, moveSpeed = 2f;
    [SerializeField] int numberOfEnemies = 5;

    private List<Transform> waypoints;

    public GameObject GetEnemyPrefab() {
        return enemyPrefab;
    }

    public List<Transform> GetWaypoints() {
        waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform) {
            waypoints.Add(child);
        }
        return waypoints;
    }

    public float GetTimeBeweenSpawns() {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor() {
        return spawnRandomFactor;
    }

    public float GetMoveSpeed() {
        return moveSpeed;
    }

    public int GetNumberOfEnemies() {
        return numberOfEnemies;
    }
}
