using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float aimDistance = 10;

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
                // attack the target.
                // Face the target.
            }
        }
    }
}
