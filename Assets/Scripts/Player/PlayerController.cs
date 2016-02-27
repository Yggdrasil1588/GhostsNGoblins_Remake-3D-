using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

//Author: [jonnoWaite]

//handles all player movement, projectiles, sound and animation
//todo: tidy up/fix animation logic
public class PlayerController : MonoBehaviour
{
    public float moveSpeed, jumpHeight, climbSpeed, gravityScale, throwForce;

    [HideInInspector]
    public float move, moveSpeedStore;

    public float knockBack, knockBackLength, knockBackCount;
    public bool knockFromRight;

   // [HideInInspector]
    public bool isThrowing, isJumping, playerCanMove;

    //public Transform groundCheck;
    //public float groundCheckRadius;
    //public LayerMask whatIsGround;
    public bool isClimbing;

    private bool isGrounded, doubleJump;

    public Transform firePoint;
    public GameObject projectilePrefab;

    private Rigidbody playerRigidbody;
    private AudioSource audioSource;

    void Start()
    {

        playerRigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        moveSpeedStore = moveSpeed;
        Physics.gravity = new Vector3(0, gravityScale, 0); //this changes the gravity scale for the entire system, it may be worthwhile to do this inside the LevelManager class (or not i don't know :D)
    }

    void FixedUpdate()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (playerCanMove)
            Movement();

        DoubleJump();
        ThrowProjectile();
    }

    #region Player Input
    //methods which detect player input 
    //todo: handle all input in an external class

    public void Movement()
    {

        if (knockBackCount <= 0)
        { //if you aren't being knocked back by an enemy do horizontal movement stuff
            move = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            transform.Translate(0, 0, move);
        }
        else
        {
            if (knockFromRight)
            {
                playerRigidbody.velocity = new Vector2(-knockBack, knockBack);
            }
            if (!knockFromRight)
            {
                playerRigidbody.velocity = new Vector2(knockBack, knockBack);
            }
            knockBackCount -= Time.deltaTime;
        }

        if (Input.GetAxis("Horizontal") > 0)
        { //flip the sprite to face direction that you are moving in
            transform.localScale = new Vector3(transform.localScale.y, transform.localScale.y, transform.localScale.y);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.localScale = new Vector3(transform.localScale.y, transform.localScale.y, -transform.localScale.y);
        }

    }

    public void DoubleJump()
    {

        if (isGrounded)
        {
            isJumping = false;
            doubleJump = false;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            Jump();
        }

        if (Input.GetButtonDown("Jump") && !doubleJump && !isGrounded)
        {
            Jump();
            doubleJump = true;
        }
    }

    public void ThrowProjectile()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            isThrowing = true;
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        }
        else
            isThrowing = false;
    }
    #endregion

    public void Jump()
    {
        isJumping = true;
        if (!isClimbing)
        {
            //audioSource.Play();
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x, jumpHeight);
        }
    }


    #region Collision Detection
    //todo: external class blah blah

    void OnCollisionEnter(Collision other)
    {

        if (other.transform.tag == "Ground")
        {
            playerCanMove = true;
            isGrounded = true;
            //transform.parent = other.transform;
        }

        if (other.transform.tag == "MovingPlatform")
        {
            playerCanMove = true;
            isGrounded = true;
            transform.parent = other.transform;
        }
    }

    void OnCollisionExit(Collision other)
    {

        if (other.transform.tag == "Ground")
        {
            isGrounded = false;
            //transform.parent = null;
        }

        if (other.transform.tag == "MovingPlatform")
        {
            isGrounded = false;
            transform.parent = null;
        }
    }
    #endregion


}