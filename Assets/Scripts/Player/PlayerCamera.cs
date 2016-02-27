using UnityEngine;

//Author: J.Anderson

/// <summary>
/// To setup drop the script onto the camera then add an empty game 
/// object to the character heirachy and set it ahead of the character
/// by about 6 units then drop the empty object in the cameraTarget box.
/// <summary>

public class PlayerCamera : MonoBehaviour
{
    public LedgeClimb ledgeClimb;

    Quaternion cameraRotation;
    public GameObject forwardCameraTarget;
    public GameObject hangingCameraTarget;
    GameObject cameraTarget;
    Vector3 cameraPosOffset;

    float velocityX;

    [Header("Camera Position")]
    [Range(-15, 15)]
    public float cameraYPos = 3.5f;
    [Range(-15, 15)]
    public float cameraZPos = 10f;
    [Range(-15, 15)]
    public float cameraXPos = 6f;
    public float dampTimeX = 0.4f;

    public bool facingLeft;

    void Start()
    {
        //ledgeClimb = GameObject.FindGameObjectWithTag("Player").GetComponent<LedgeClimb>();
    }

    void Update()
    {
        if (!ledgeClimb.hangingOffLedge)
            cameraTarget = forwardCameraTarget;
        else if (ledgeClimb.hangingOffLedge)
            cameraTarget = hangingCameraTarget;
    }

    void FixedUpdate()
    {
        IsFlipped();
        CameraPos();
    }

    void CameraPos()
    {
        // Setup camera offset in inspector
        cameraPosOffset.y = cameraTarget.transform.position.y + cameraYPos;
        cameraPosOffset.z = cameraTarget.transform.position.z + cameraZPos;
        cameraPosOffset.x = cameraTarget.transform.position.x + cameraXPos;

        // Set the smooth between camera target switch
        float smoothDampX = Mathf.SmoothDamp(gameObject.transform.position.x, cameraTarget.transform.position.x, ref velocityX, dampTimeX);

        // camera rotation
        cameraRotation.y = 0.0f; //had to change because of weird rotation issue -jonno
        cameraRotation.w = 0.0f;

        transform.rotation = cameraRotation;
        transform.position = new Vector3(smoothDampX, cameraPosOffset.y, cameraPosOffset.z);
    }

    void IsFlipped()
    {
        if (Input.GetAxis("Horizontal") <= -.001)
        {
            facingLeft = false;
        }
        if (Input.GetAxis("Horizontal") >= .001)
        {
            facingLeft = true;
        }
    }
}


