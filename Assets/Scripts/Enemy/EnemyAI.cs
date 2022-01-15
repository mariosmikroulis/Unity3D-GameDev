using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float aimDistance = 10;

    public float attackDamage = 9f;
    public float attackSpeed = 1f;

    private float attackCd = 0f;

    public Transform player;
    NavMeshAgent agent;

    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        float distance = Vector3.Distance(player.position, transform.position);

        if(distance <= aimDistance) {
            agent.SetDestination(player.position);

            if(distance <= agent.stoppingDistance) {
                FaceTarget();

                attackCd -= Time.deltaTime;
                // attack the target
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void attackPlayer() {
        Generic.setHealth(attackDamage);
        attackCd = 1 / attackSpeed;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aimDistance);
    }
}
