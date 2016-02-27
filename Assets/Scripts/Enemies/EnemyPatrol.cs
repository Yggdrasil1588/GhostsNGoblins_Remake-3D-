using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

//simple 2d enemy ai - walks left - right, detecting wall and platform edge
public class EnemyPatrol : MonoBehaviour {

    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool atEdge;
    public Transform edgeCheck;

	private Rigidbody enemyRigidbody;

    void Start() {

        enemyRigidbody = GetComponent<Rigidbody>();
    }

	void Update () {

        //hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        //atEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        Vector3 dwn = transform.TransformDirection(Vector3.down);
        atEdge =! ((Physics.Raycast(edgeCheck.transform.position, dwn, 1f, whatIsWall)));

        Vector3 right = transform.TransformDirection(Vector3.right);
        hittingWall = ((Physics.Raycast(wallCheck.transform.position, right, 1f, whatIsWall)));
        /*
        if (hittingWall || !atEdge) {
            moveRight = !moveRight;
        }
         */

        if(atEdge){
            moveRight = !moveRight;
        } else if (hittingWall) {
            moveRight = !moveRight;
        }

        if (moveRight) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            enemyRigidbody.velocity = new Vector2(moveSpeed, enemyRigidbody.velocity.y);
        } else {
            transform.localScale = new Vector3(1f, 1f, 1f);
            enemyRigidbody.velocity = new Vector2(-moveSpeed, enemyRigidbody.velocity.y);
        }	
	}


}