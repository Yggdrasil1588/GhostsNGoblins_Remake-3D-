using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]


public class HeadStomp : MonoBehaviour {

    public int damageToGive;

    public float bounceOnEnemy;

    private new Rigidbody2D rigidbody2D;

    void Start() {

        rigidbody2D = transform.parent.GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Enemy"){
            other.GetComponent<EnemyHealthManager>().GiveDamage(damageToGive);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, bounceOnEnemy);
        }
    }

}