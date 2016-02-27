using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

//handles all player movement, projectiles, sound and animation
//todo: tidy up/fix animation logic
public class PlayerController : MonoBehaviour {

    public float moveSpeed, jumpHeight, climbSpeed, gravityScale;
    private float move, moveSpeedStore;

    public float knockBack, knockBackLength, knockBackCount;
    public bool knockFromRight, isAnimated;

    //public Transform groundCheck;
    //public float groundCheckRadius;
    //public LayerMask whatIsGround;
    public bool isClimbing;
    private bool isGrounded, doubleJump;

    public Transform firePoint;
    public GameObject projectilePrefab;

    private Rigidbody playerRigidbody;
	private AudioSource audioSource;
    private Animator anim;

    void Start() {

        playerRigidbody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
        
        if (isAnimated) {
            anim = GetComponent<Animator>();
        } 

        moveSpeedStore = moveSpeed; 
        Physics.gravity = new Vector3(0, gravityScale, 0); //this changes the gravity scale for the entire system, it may be worthwhile to do this inside the LevelManager class (or not i don't know :D)
    }

    void FixedUpdate() {

        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        Movement();
        DoubleJump();
        ThrowProjectile();
    }

	void Update () {

        if (isAnimated) { //if you have set up an animator for the player, set this bool to true in the inspector
            PlayerAnimation();
        } else {
            return;
        }
	}

    #region Player Input
    //methods which detect player input 
    //todo: handle all input in an external class

    public void Movement() {

        if (knockBackCount <= 0) { //if you aren't being knocked back by an enemy do horizontal movement stuff
            move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            transform.Translate(move, 0, 0);
        } else {
            if (knockFromRight) {
                playerRigidbody.velocity = new Vector2(-knockBack, knockBack);
            }
            if (!knockFromRight) {
                playerRigidbody.velocity = new Vector2(knockBack, knockBack);
            }
            knockBackCount -= Time.deltaTime;
        }

        if (Input.GetAxis("Horizontal") > 0) { //flip the sprite to face direction that you are moving in
            transform.localScale = new Vector3(1f, 1f, 1f);
        } else if (Input.GetAxis("Horizontal") < 0) {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

    }

    public void DoubleJump() {

        if (isGrounded) {
            doubleJump = false;
        }
        if (Input.GetButtonDown("Jump") && isGrounded) {
            Jump();
        }

        if (Input.GetButtonDown("Jump") && !doubleJump && !isGrounded) {
            Jump();
            doubleJump = true;
        }
    }

    public void ThrowProjectile() {

        if (Input.GetButtonDown("Fire1")) {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
    }
    #endregion

    public void Jump() {

        if(!isClimbing){
            audioSource.Play();
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);
        }
    }



    #region Player Animation
    //player animation logic
    public void PlayerAnimation() {

        //todo: put in an external class
        //tidy up, make logic better

        if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") >= 0) { //run animation stuff
            anim.SetBool("isRunning", true);
        } else if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") >= 0) {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetAxis("Vertical") < 0) { //crouch animation stuff
            anim.SetBool("isCrouching", true);
            moveSpeed = 0;
            isClimbing = true; //disable jumping
        } else {
            moveSpeed = moveSpeedStore;
            anim.SetBool("isCrouching", false);
            isClimbing = false;
        }

        if(!isGrounded){ //jump animation stuff
            anim.SetBool("isJumping", true);
        } else {
            anim.SetBool("isJumping", false);
        }

        if (Input.GetButtonDown("Fire1")) { //throw animation stuff
            anim.SetBool("isThrowing", true);
        } else {
            anim.SetBool("isThrowing", false);
        }
    }
    #endregion

    #region Collision Detection
    //todo: external class blah blah

    void OnCollisionEnter(Collision other) {

        if(other.transform.tag == "Ground"){
            isGrounded = true;
            //transform.parent = other.transform;
        }

        if (other.transform.tag == "MovingPlatform") {
            isGrounded = true;
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit(Collision other) {

        if (other.transform.tag == "Ground") {
            isGrounded = false;
            //transform.parent = null;
        }

        if (other.transform.tag == "MovingPlatform") {
            isGrounded = false;
            transform.parent = null;
        }
    }
    #endregion


}