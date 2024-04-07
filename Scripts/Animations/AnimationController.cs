using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    private bool isWalking;
    private bool isRunning;
    private bool isJumping;
    private bool isAiming;
    private bool isAimingForward;
    private bool isAimingBackward;
    private bool isAimingLeft;
    private bool isAimingRight;

    void Update()
    {
        bool isWalkingForward = Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0;
        bool isWalkingBackward = Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < 0;
        bool isWalkingLeftward = Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0;
        bool isWalkingRightward = Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0;

        bool _verticalBlock = Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S);
        bool _horizontalBlock = Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D);

        isWalking = isWalkingForward || isWalkingBackward || isWalkingLeftward || isWalkingRightward;
        isRunning = Input.GetKey(KeyCode.LeftShift) && isWalking;
        isJumping = Input.GetKey(KeyCode.Space);

        isAiming = Input.GetMouseButton(1) && !isRunning && !isJumping;
        isAimingForward = isAiming && isWalkingForward;
        isAimingBackward = isAiming && isWalkingBackward;
        isAimingLeft = isAiming && isWalkingLeftward;
        isAimingRight = isAiming && isWalkingRightward;

        // setam variabilele de animatie in Animatorul corespunzator
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isAiming", isAiming);
        animator.SetBool("isAimingForward", isAimingForward);
        animator.SetBool("isAimingBackward", isAimingBackward);
        animator.SetBool("isAimingLeft", isAimingLeft);
        animator.SetBool("isAimingRight", isAimingRight);
    }
}
