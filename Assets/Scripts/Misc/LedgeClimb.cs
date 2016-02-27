using UnityEngine;

//Author: J.Anderson

public class LedgeClimb : MonoBehaviour 
{

    Rigidbody playerRigidbody;
    Transform hangTransform;
    Transform climbLerpTransform;
    PlayerController playerJump;

    [Header("Tag Input")]
    public string floorTag;

    bool canLerp;
    bool playerCanMove;
    public bool hangingOffLedge;

    void Awake()
    {
        if (gameObject.GetComponent<PlayerController>() == null)
            playerJump = null;
        else
            playerJump = gameObject.GetComponent<PlayerController>();

        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void Start()
    {
        hangingOffLedge = false;
    }

    void Update()
    {
        if (playerJump != null)
            playerJump.playerCanMove = playerCanMove;

        LedgeGrab();
    }

    void LedgeGrab()
    {
        if (canLerp)
        {
            playerRigidbody.useGravity = false;
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                print("Climbing");
                ClimbUpLedge();
            }
        }
    }

    void ClimbUpLedge()
    {
        playerCanMove = false;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, climbLerpTransform.position, 1);
        playerRigidbody.isKinematic = false;
        playerRigidbody.useGravity = true;
        playerCanMove = true;
        hangingOffLedge = false;
        canLerp = false;


    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == floorTag)
        {
            playerCanMove = true;
        }

        if (collision.gameObject.tag == "Climbable")
        {
            hangTransform = collision.transform.GetChild(1).transform;
            transform.position = hangTransform.position;
            playerRigidbody.isKinematic = true;
            climbLerpTransform = collision.transform.GetChild(0).transform;
            print("is hanging");
            playerCanMove = false;
            hangingOffLedge = true;
            canLerp = true;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Climbable")
        {
            print("is climbing/falling");
            canLerp = false;
            playerCanMove = true;
            //playerRigidbody.isKinematic = false;
            //playerRigidbody.useGravity = true;
            hangingOffLedge = false;
        }
    }
}
