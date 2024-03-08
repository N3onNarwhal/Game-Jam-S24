using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController cc;
    [SerializeField] float JumpPower = 5f;
    [SerializeField] float SkatingSpeed = 20f;
    [SerializeField] float WalkingSpeed = 7.5f;

    bool isGrounded;
    bool isJumping;
    bool isSkating;

    float currentSpeed;
    float gravity = -9.8f;

    Vector3 velocity;
    Vector3 move;

    void Start()
    {
        
    }

    void Update()
    {
        // Apply gravity
        if (!isGrounded)
        {
            if (isJumping)
            {
                isJumping = false;
            }
            velocity.y += gravity * Time.deltaTime;
            cc.Move(velocity * Time.deltaTime);
        }
        else if (isJumping)
        {
            isGrounded = false;
            velocity.y = 0;
            velocity.y += JumpPower;
            cc.Move(velocity * Time.deltaTime);
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }

        move = Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward;
        
        // Determine skating or walking
        isSkating = Input.GetKey(KeyCode.LeftShift);
        if (isSkating)
        {
            currentSpeed = SkatingSpeed;
        }
        else
        {
            currentSpeed = WalkingSpeed;
        }
        
        cc.Move(move * currentSpeed * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.CompareTag("Ground") && !isGrounded)
        {
            isGrounded = true;
        }
    }
}
