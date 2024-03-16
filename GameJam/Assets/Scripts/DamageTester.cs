using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTester : MonoBehaviour
{
    public EnemyAttributes enemyAtt;
    public PlayerHealth jaxHealth;

    private void Update()
    {
        // deal player damage to enemy health
        if (Input.GetKeyDown(KeyCode.F11))
        {
            jaxHealth.DealDamage(enemyAtt.gameObject);
        }

        // deal enemy damage to the player health
        if (Input.GetKeyDown(KeyCode.F12))
        {
            enemyAtt.DealDamage(jaxHealth.gameObject);
        }
    }
}
