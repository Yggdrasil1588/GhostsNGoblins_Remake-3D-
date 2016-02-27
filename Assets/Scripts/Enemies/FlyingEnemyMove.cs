using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

public class FlyingEnemyMove : MonoBehaviour {

    private PlayerController thePlayer;

    public float moveSpeed, playerRange;
    private float playerDistance;

    //public LayerMask playerLayer;

    private bool playerInRange;

	void Start () {

        thePlayer = FindObjectOfType<PlayerController>();

        
	}

	void Update () {

        playerDistance = Vector3.Distance(thePlayer.transform.position, transform.position);

        if(playerDistance <= playerRange){
            playerInRange = true;
        } else {
            playerInRange = false;
        }

        //playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);

        if (playerInRange) {
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
        } 
	}

    void OnDrawGizmosSelected() {

        Gizmos.DrawWireSphere(transform.position, playerRange);

        
    }

}