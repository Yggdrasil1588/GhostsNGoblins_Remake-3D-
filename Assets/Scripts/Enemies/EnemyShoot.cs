﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class EnemyShoot : MonoBehaviour {

    public float playerRange;
    public GameObject enemyProjectile;
    public PlayerController player;
    public Transform launchPoint;

    public float waitBetweenShots;
    private float shotCounter;

	void Start () {

        player = FindObjectOfType<PlayerController>();
        shotCounter = waitBetweenShots;
	
	}

	void Update () {

        Debug.DrawLine(new Vector3 (transform.position.x - playerRange, transform.position.y, transform.position.z), new Vector3(transform.position.x + playerRange, transform.position.y, transform.position.z));

        shotCounter -= Time.deltaTime;

        if (transform.localScale.x < 0 && player.transform.position.x > transform.position.x && player.transform.position.x < transform.position.x + playerRange && shotCounter < 0) {
            Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;
        }

        if (transform.localScale.x > 0 && player.transform.position.x < transform.position.x && player.transform.position.x > transform.position.x - playerRange && shotCounter < 0) {
            Instantiate(enemyProjectile, launchPoint.position, launchPoint.rotation);
            shotCounter = waitBetweenShots;
        }
	}

}