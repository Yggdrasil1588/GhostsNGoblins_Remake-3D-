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

	private Rigidbody2D enemyRigidbody2D;

    void Start() {

        enemyRigidbody2D = GetComponent<Rigidbody2D>();
    }

	void Update () {

        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);
        atEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall || !atEdge) {
            moveRight = !moveRight;
        }

        if (moveRight) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            enemyRigidbody2D.velocity = new Vector2(moveSpeed, enemyRigidbody2D.velocity.y);
        } else {
            transform.localScale = new Vector3(1f, 1f, 1f);
            enemyRigidbody2D.velocity = new Vector2(-moveSpeed, enemyRigidbody2D.velocity.y);
        }	
	}


}