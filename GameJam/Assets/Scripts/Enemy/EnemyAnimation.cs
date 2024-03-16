using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public GameObject officerRig;
    Animator officerAnim;
    bool moving;
    Rigidbody rb;

    void Start()
    {
        officerAnim = officerRig.GetComponent<Animator>();
        officerAnim.SetBool("isMoving", false);
        rb = officerRig.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (officerAnim == null)
        {
            Debug.Log("Animator is null");
        }

        if (rb.velocity != Vector3.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        officerAnim.SetBool("isMoving", moving);
    }
}
