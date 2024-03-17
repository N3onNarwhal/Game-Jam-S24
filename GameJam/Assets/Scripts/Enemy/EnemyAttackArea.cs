using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    public int damage = 20;
    public EnemyAttributes Officer;

    // private void OnCollisionEnter(Collision other)
    // {
    //     Debug.Log("On collision EAA");
    //     string tag = other.gameObject.tag;
    //     Debug.Log(tag);
    //     if (other.gameObject.tag == "Player")
    //     {
    //         PlayerHealth Jax = other.gameObject.GetComponent<PlayerHealth>();
    //         Jax.TakeDamage(damage);
    //         Debug.Log("Player hit");
    //     }
    // }
}
