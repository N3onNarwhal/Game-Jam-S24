using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] GameObject attackAnim;
    [SerializeField] GameObject idleAnim;
    [SerializeField] GameObject runAnim;
    [SerializeField] GameObject skateAnim;

    [SerializeField] GameObject attackArea;

    [SerializeField] AudioSource jaxAttack;

    Animator attack;
    

    bool animFinished = true;
    float NTime = 0.0f;
    float animTimer;

    void Start()
    {
       attack = attackAnim.GetComponent<Animator>();
       attackArea.SetActive(false);
       animTimer = attack.GetCurrentAnimatorStateInfo(0).length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    // if left click is pressed
        {
            if (NTime == 0.0f)
            {
                Attack();
                animFinished = false;
                attackAnim.SetActive(true);
                idleAnim.SetActive(false);
                runAnim.SetActive(false);
                skateAnim.SetActive(false);
                
            }
        }
        if (animFinished)
        {
            attackAnim.SetActive(false);
            attackArea.SetActive(false);
        }

        NTime = attack.GetCurrentAnimatorStateInfo(0).normalizedTime;
        
        if(NTime >= 1.0f) 
        {
            NTime = 0.0f;
            animFinished = true;
            attackAnim.SetActive(false);
            attackArea.SetActive(false);
            idleAnim.SetActive(true);
        }
    }

    void Attack()
    {
        attackArea.SetActive(true);
    }
}
