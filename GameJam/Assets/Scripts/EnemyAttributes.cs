using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttributes : MonoBehaviour
{
    public int health;
    public int attack;
    [SerializeField] GameObject Enemy;

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void DealDamage(GameObject Jax)
    {
        var jaxHealth = Jax.GetComponent<PlayerHealth>();
        if (jaxHealth != null)
        {
            jaxHealth.TakeDamage(attack);
        }
    }
}
