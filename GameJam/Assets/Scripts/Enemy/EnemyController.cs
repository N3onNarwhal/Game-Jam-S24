using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject eAttackArea;
    [SerializeField] GameObject Officer;

    public float lookRadius;

    NavMeshAgent agent;
    Transform target;

    public AudioSource enemyAttack;

    void Start()
    {
        target = PlayerManager.instance.player.transform;
        //eAttackArea.SetActive(false);
    }

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

            if (distance <= agent.stoppingDistance)
            {
                Attack();
                FaceTarget();
            }
        }
        
    }

    void FaceTarget ()
    {
        Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
		transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private IEnumerator Attack()
    {
        enemyAttack.Play(0);
        yield return new WaitForSeconds(1);
    }
}
