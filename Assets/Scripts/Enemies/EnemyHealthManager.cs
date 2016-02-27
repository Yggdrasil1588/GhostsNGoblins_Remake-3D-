using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class EnemyHealthManager : MonoBehaviour {

    public int enemyHealth, pointsOnDeath;
    public GameObject deathEffect;

	void Update () {

        if (enemyHealth <= 0) {

            Instantiate(deathEffect, transform.position, transform.rotation);
            ScoreManager.AddPoints(pointsOnDeath);
            Destroy(gameObject);
        }
	}

    public void GiveDamage(int damageToGive) {

        enemyHealth -= damageToGive;
        GetComponent<AudioSource>().Play();
    }

}