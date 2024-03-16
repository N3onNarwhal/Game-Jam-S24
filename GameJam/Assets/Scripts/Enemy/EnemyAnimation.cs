using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public GameObject officer;
    public GameObject officerRig;
    Animator officerAnim;
    bool moving;
    Rigidbody rb;

    void Start()
    {
        officerAnim = officerRig.GetComponent<Animator>();
        officerAnim.SetBool("isMoving", false);
        rb = officer.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (rb.velocity != Vector3.zero || transform.hasChanged)
        {
            moving = true;
            transform.hasChanged = false;
        }
        else
        {
            moving = false;
        }
        officerAnim.SetBool("isMoving", moving);
    }
}
