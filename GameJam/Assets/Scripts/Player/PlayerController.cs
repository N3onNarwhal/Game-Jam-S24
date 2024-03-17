using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] CharacterController cc;
    [SerializeField] float JumpPower = 5f;
    [SerializeField] float SkatingSpeed = 20f;
    [SerializeField] float WalkingSpeed = 7.5f;
    [SerializeField] Transform CamPivot;

    [SerializeField] GameObject attackAnim;
    [SerializeField] GameObject idleAnim;
    [SerializeField] GameObject runAnim;
    [SerializeField] GameObject skateAnim;

    bool isGrounded;
    bool isJumping;
    bool isMoving;
    bool isSkating;

    float currentSpeed;
    float gravity = -9.8f;
    float xRot;

    Vector3 velocity;
    Vector3 move;

    void Start()
    {
        currentSpeed = WalkingSpeed;
    }
    void Awake()
    {
        attackAnim.SetActive(false);
        idleAnim.SetActive(true);
        runAnim.SetActive(false);
        skateAnim.SetActive(false);
    }

    void Update()
    {
        if (!PauseMenu.isPaused) {

        if (cc.velocity.x == 0 && cc.velocity.y == 0 && cc.velocity.z == 0)
        {
            isMoving = false;
        }
        else 
        {
            isMoving = true;
        }

        if (attackAnim.activeInHierarchy)
        {
            idleAnim.SetActive(false);
            runAnim.SetActive(false);    // make sure other animations don't play during attack
            skateAnim.SetActive(false);
        }
        else if (isMoving)   // if moving
        {
            if (!isSkating)
            {
                idleAnim.SetActive(false);
                runAnim.SetActive(true);    // run anim active
                skateAnim.SetActive(false);
            }
            else
            {
                idleAnim.SetActive(false);
                runAnim.SetActive(false);
                skateAnim.SetActive(true);  // skating anim active
            }
        }
        else    // if not moving
        {
            idleAnim.SetActive(true);   // idle anim active
            runAnim.SetActive(false);
            skateAnim.SetActive(false);
        }

        // Apply gravity
        if (cc.gameObject.tag != "Ground")
        {
            isGrounded = false;
        }
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
            StartCoroutine(Skating());
        }
        
        cc.Move(move * currentSpeed * Time.deltaTime);

        // Cam Rotation
        transform.Rotate(0, 1.75f*Input.GetAxis("Mouse X"), 0);

        // X Rotation of Camera
        xRot -= 0.5f*Input.GetAxis("Mouse Y");
        xRot = Mathf.Clamp(xRot, 8f, 28f);
        CamPivot.eulerAngles = new Vector3(xRot, transform.eulerAngles.y, 0);

        }
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.CompareTag("Ground") && !isGrounded)
        {
            isGrounded = true;
        }
    }
    
    private IEnumerator Skating()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = SkatingSpeed;        //goes fast

            yield return new WaitForSeconds(2); //AVERY THIS IS THE VALUE YOU CHANGE (the 2)

            currentSpeed = WalkingSpeed;        //goes slow
        }
    }
    
    // void OnCollisionEnter(Collision other)
    // {
    //     Debug.Log("OnCollisioniEnter");
    //     GameObject enem = other.gameObject;
    //     if (enem.tag == "EnemyAttackArea" || enem.tag == "Enemy")
    //     {
    //         Debug.Log("Enemy tag");
    //         GetComponent<PlayerHealth>().TakeDamage(20);
    //     }
    // }
    // void OnCollisionExit(Collision other)
    // {
    //     Debug.Log("collision exit");
    // }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        GameObject enem = other.gameObject;
        if (enem.tag == "Enemy")
        {
            Debug.Log("Enemy tag");
            GetComponent<PlayerHealth>().TakeDamage(20);
        }
    }
}
