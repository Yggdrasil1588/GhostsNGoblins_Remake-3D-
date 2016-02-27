using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class HurtPlayer : MonoBehaviour {

    public int damageToGive;

    private PlayerController player;

    void Start() {

        player = FindObjectOfType<PlayerController>();
    }

    void OnTriggerEnter(Collider other) {

        if (other.tag == "Player") {
            HealthManager.HurtPlayer(damageToGive);
            player.knockBackCount = player.knockBackLength;

            if (other.transform.position.x < transform.position.x) {
                player.knockFromRight = true;
            } else {
                player.knockFromRight = false;
            }
        }
    }

}