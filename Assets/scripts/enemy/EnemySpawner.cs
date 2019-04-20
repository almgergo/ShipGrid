using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject EnemyObject;
    public float SpawnCooldownInSeconds;
    public float SpawnVariance;

    private float nextSpawn;
    // Start is called before the first frame update
    void Start() {
        nextSpawn = Time.time + SpawnCooldownInSeconds;
    }

    // Update is called once per frame
    void Update() {
        if (nextSpawn <= Time.time) {
            SpawnEnemy();
        }
    }

    private void SpawnEnemy() {
        Vector3 displacement = new Vector3(
            Random.Range(-SpawnVariance, SpawnVariance),
            0.5f,
            Random.Range(-SpawnVariance, SpawnVariance)
        );

        GameObject newEnemy = Instantiate(EnemyObject, transform.position + displacement, Quaternion.identity);
        newEnemy.transform.SetParent(transform);
        nextSpawn = Time.time + SpawnCooldownInSeconds * 100000;
    }
}