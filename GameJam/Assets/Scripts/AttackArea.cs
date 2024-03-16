using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    public int damage = 25;
    public PlayerHealth Jax;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy hit");
            EnemyAttributes enemyAtt = other.GetComponent<EnemyAttributes>();
            Jax.DealDamage(enemyAtt.gameObject);
        }
    }
}