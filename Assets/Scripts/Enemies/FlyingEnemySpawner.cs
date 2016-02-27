using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class FlyingEnemySpawner : MonoBehaviour {

    public float timeToSpawn, timer;
    public int ammountToSpawn, maxEnemiesInScene;
    public GameObject enemy, spawnSpot;
    public FlyingEnemyMove[] enemiesInScene;
    private int enemyCount;
    public bool playerInZone;

	void Update () {

        timer += Time.deltaTime;

        if (playerInZone) {
            SpawnEnemy();
        }
        
	}

    void SpawnEnemy() {

        enemiesInScene = FindObjectsOfType<FlyingEnemyMove>();
        enemyCount = enemiesInScene.Length;

        if(timer > timeToSpawn && enemyCount < maxEnemiesInScene){

            for (int x = 0; x < ammountToSpawn; x++) {
                timer = 0f;
                Vector3 randomSeed = new Vector3(x + Random.Range(0, 4), Random.Range(0,5));
                Instantiate(enemy, spawnSpot.transform.position + randomSeed, Quaternion.identity);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player"){
            playerInZone = true;
        } 
    }

    void OnTriggerExit2D(Collider2D other) {

        if (other.tag == "Player") {
            playerInZone = false;
        }
    }


}