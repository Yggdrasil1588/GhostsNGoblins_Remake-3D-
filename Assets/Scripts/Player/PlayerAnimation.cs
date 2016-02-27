using UnityEngine;

using System.Collections;


//Author: J.Anderson

public class PlayerAnimation : MonoBehaviour
{
    PlayerController playerController;
    LedgeClimb ledgeClimb;
    Animator playerAnimator;

    float moveAnimFloat;
    bool runAnimBool;
    bool throwingAnim;
    bool jumpAnim;
    bool hangingAnim;

    void Awake()
    {
        playerAnimator = gameObject.GetComponent<Animator>();
        playerController = gameObject.GetComponent<PlayerController>();
        ledgeClimb = gameObject.GetComponent<LedgeClimb>();
    }


    void Update()
    {
        AnimationTriggers();
        GetBools();
    }

    void GetBools()
    {
        moveAnimFloat = playerController.move;

        if (moveAnimFloat != 0)
            runAnimBool = true;
        else
            runAnimBool = false;

        throwingAnim = playerController.isThrowing;
        jumpAnim = playerController.isJumping;
        hangingAnim = ledgeClimb.hangingOffLedge;
    }

    void AnimationTriggers()
    {
       playerAnimator.SetBool("Run", runAnimBool);
        playerAnimator.SetBool("Throw", throwingAnim);
        playerAnimator.SetBool("Jump", jumpAnim);
        playerAnimator.SetBool("Hanging", hangingAnim);

    }
}
