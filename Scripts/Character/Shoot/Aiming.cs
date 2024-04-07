using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public Transform target;
    private bool isWalking;
    private bool isRunning;
    private bool isJumping;
    private bool isAiming;

    void Update()
    {
        bool isWalkingForward = Input.GetKey(KeyCode.W) || Input.GetAxis("Vertical") > 0;
        bool isWalkingBackward = Input.GetKey(KeyCode.S) || Input.GetAxis("Vertical") < 0;
        bool isWalkingLeftward = Input.GetKey(KeyCode.A) || Input.GetAxis("Horizontal") < 0;
        bool isWalkingRightward = Input.GetKey(KeyCode.D) || Input.GetAxis("Horizontal") > 0;

        isWalking = isWalkingForward || isWalkingBackward || isWalkingLeftward || isWalkingRightward;
        isRunning = Input.GetKey(KeyCode.LeftShift) && isWalking;
        isJumping = Input.GetKey(KeyCode.Space);

        isAiming = Input.GetMouseButton(1) && !isRunning && !isJumping;


        if (isAiming)
        {

            // obtinem directia catre obiect
            Vector3 direction = target.position - transform.position;

            // reset rotation
            direction.y = 0f;

            // transform
            Quaternion rotation = Quaternion.LookRotation(direction);

            // aplicam rotatia
            transform.rotation = Quaternion.Euler(0f, rotation.eulerAngles.y, 0f);

        }
    }
}
