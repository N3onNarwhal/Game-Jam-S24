using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{
    public int damage = 25;
    public EnemyAttributes Officer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player hit");
            PlayerHealth Jax = other.GetComponent<PlayerHealth>();
            Jax.TakeDamage(damage);
        }
    }
}
