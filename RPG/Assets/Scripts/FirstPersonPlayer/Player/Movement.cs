using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Village/ First Person/ Movement")]
public class Movement : MonoBehaviour
{
    [Header("Speed Variables")]
    public float moveSpeed = 5.0f;
    public float walkSpeed = 5.0f, crouchSpeed = 2.5f, runSpeed = 15.0f, jumpSpeed = 8.0f;

    private float gravity = 20;
    private Vector3 moveDirection;
    private CharacterController charC;

    void Start()
    {
        charC = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (charC.isGrounded)
        {
            if (Input.GetButton("Sprint"))
            {
                moveSpeed = runSpeed;
            }

            else if (Input.GetButton("Crouch"))
            {
                moveSpeed = crouchSpeed;
            }

            else
            {
                moveSpeed = walkSpeed;
            }


            moveDirection = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed);

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }


            


        }
        moveDirection.y -= gravity * Time.deltaTime;
        charC.Move(moveDirection * Time.deltaTime);

    }
}
