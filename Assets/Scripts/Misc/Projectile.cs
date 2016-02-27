using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class Projectile : MonoBehaviour {

    private PlayerController player;

    public GameObject enemyDeathEffect, impactEffect;

    public int pointsForKill, damageToGive;
    public float speed;

    private Rigidbody projectileRigidbody;

	void Start () {

        player = FindObjectOfType<PlayerController>();

        projectileRigidbody = GetComponent<Rigidbody>();

        if(player.transform.localScale.x < 0){
            speed = -speed;
            transform.localScale = new Vector3(-1f,1f,1f);
        }
	}

	void FixedUpdate () {

        projectileRigidbody.velocity = new Vector2(speed, projectileRigidbody.velocity.y);
	}

    void OnCollisionEnter(Collision other) {

        /*
        if(other.tag == "Enemy"){
            other.GetComponent<EnemyHealthManager>().GiveDamage(damageToGive);
        }
                */
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

    }

}