using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float aimDistance = 10;

    public float attackDamage = 9f;
    public float attackSpeed = 1f;

    public float attackCd = 0f;

    public Transform player;
    NavMeshAgent agent;

    // Gets an enemy AI
    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    // Controls enemy movement and actions
    void Update() {
        float distance = Vector3.Distance(player.position, transform.position);

        if(distance <= aimDistance) {
            agent.SetDestination(player.position);

            if(distance <= agent.stoppingDistance + 1) {
                FaceTarget();

                attackCd -= Time.deltaTime;
                // attack the target
                if (attackCd <= 0f) {
                    attackPlayer();
                }
            }
        }
    }

    // Faces player
    void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // Attacks player
    void attackPlayer() {
        Generic.removeHealth(attackDamage);
        attackCd = 1 / attackSpeed;
    }

    // Draws circle for editor (not for game)
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aimDistance);
    }
}
