using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
    public Text SpawnCooldownText;
    public GameObject EnemyObject;
    public float SpawnCooldownReductionCooldown;
    public float SpawnCooldownInSeconds;
    public float SpawnVariance;

    private float nextSpawn;
    private float nextSpeedUp;
    // Start is called before the first frame update
    void Start() {
        nextSpawn = Time.time + SpawnCooldownInSeconds;
        nextSpeedUp = Time.time + SpawnCooldownReductionCooldown;
    }

    // Update is called once per frame
    void Update() {
        if (nextSpawn <= Time.time) {
            SpawnEnemy();
        }
    }

    void FixedUpdate() {
        if (Time.time >= nextSpeedUp) {
            this.ReduceSpawnCooldown();
        }
        SpawnCooldownText.text = "Spawn interval: " + SpawnCooldownInSeconds;
    }

    private void SpawnEnemy() {
        Vector3 displacement = new Vector3(
            Random.Range(-SpawnVariance, SpawnVariance),
            0.5f,
            Random.Range(-SpawnVariance, SpawnVariance)
        );

        GameObject newEnemy = Instantiate(EnemyObject, transform.position + displacement, Quaternion.identity);
        newEnemy.transform.SetParent(transform);
        nextSpawn = Time.time + SpawnCooldownInSeconds;
    }

    private void ReduceSpawnCooldown() {
        SpawnCooldownInSeconds *= 0.75f;
        nextSpeedUp = Time.time + SpawnCooldownReductionCooldown;
    }
}