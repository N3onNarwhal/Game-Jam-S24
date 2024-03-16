using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] GameObject attackAnim;
    [SerializeField] GameObject idleAnim;
    [SerializeField] GameObject runAnim;
    [SerializeField] GameObject skateAnim;

    Animator attack;

    //AnimatorStateInfo animStateInfo;
    bool animFinished = true;
    public float NTime = 0.0f;

    void Start()
    {
       attack = attackAnim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))    // if left click is pressed
        {
            if (NTime == 0.0f)
            {
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
        }

        NTime = attack.GetCurrentAnimatorStateInfo(0).normalizedTime;
        
        if(NTime >= 1.0f) 
        {
            NTime = 0.0f;
            animFinished = true;
            attackAnim.SetActive(false);
            idleAnim.SetActive(true);
            runAnim.SetActive(true);
            skateAnim.SetActive(true);
        }
    }
}
