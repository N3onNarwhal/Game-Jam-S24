using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    public int health;
    public int attack;
    [SerializeField] GameObject Enemy;

    [SerializeField] AudioSource enemyHit;
    [SerializeField] AudioSource enemyDeath;
    [SerializeField] AudioSource jaxHit;

    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health == 0)
        {
            enemyDeath.Play(0);
            Destroy(gameObject);
        }
        else
        {
            enemyHit.Play(0);
        }
    }

    public void DealDamage(GameObject Jax)
    {
        var jaxHealth = Jax.GetComponent<PlayerHealth>();
        if (jaxHealth != null)
        {
            jaxHit.Play(0);
            jaxHealth.TakeDamage(attack);
        }
    }
}
