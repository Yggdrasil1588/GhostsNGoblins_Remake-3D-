using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class LadderClimb : MonoBehaviour {

    private PlayerController player;
    private Rigidbody2D playerRigidbody;

	private float gravityStore;

    public bool playerInZone;

	void Start () {

        player = FindObjectOfType<PlayerController>();
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        gravityStore = playerRigidbody.gravityScale;
	}

	void Update () {

        if(HealthManager.playerHealth <= 0){
            playerInZone = false;
        }
        
        if (playerInZone) {
            
            if(Input.GetAxis("Vertical") > 0){
                player.transform.Translate(new Vector3(0, player.climbSpeed * Time.deltaTime, 0));
            } else if(Input.GetAxis("Vertical") < 0){
                player.transform.Translate(new Vector3(0, -player.climbSpeed * Time.deltaTime, 0));
            }
        }  
        
	}

    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player"){
            playerInZone = true;
            player.isClimbing = true;
            playerRigidbody.gravityScale = 0;
            playerRigidbody.velocity = new Vector2(0,0);
        }
    }

    void OnTriggerExit2D(Collider2D other) {

        if (other.tag == "Player") {
            playerInZone = false;
            player.isClimbing = false;
            playerRigidbody.gravityScale = gravityStore;
        }

    }

}