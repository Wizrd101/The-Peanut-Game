using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Followed a video tutorial: https://www.youtube.com/watch?v=c8Nq19gkNfs
// The video was a part of it, the chasing part was mine

public class EnemyMovement : MonoBehaviour
{
    // Declaring the variables
    public NavMeshAgent agent;

    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    //bool isChasing;
    float patrolSpeed = 30;
    //float chaseSpeed = 50;

    public Vector3 player;
    public float triggerDist = 5000;
    Vector3 moveDir;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        agent.speed = patrolSpeed;
    }

    void Update()
    {
        float playerPosition = player.magnitude;
        moveDir = (player.x - agent.transform.position.x, player.y - agent.transform.position.y, player.z - agent.transform.position.z);
        float distToPlayer = moveDir.magnitude;
        // float distToPlayer = (player.transform.position - agent.transform.position).magnitude;
        if (distToPlayer <= triggerDist)
        {
            agent.SetDestination(player);
            Debug.Log("Chasing Player");
        }
        // If we are close enough to the waypoint, change to the next waypoint
        if (Vector3.Distance(transform.position, target) <= 1)
        {
            Debug.Log("Going to next waypoint");
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    // Changes between the waypoints
    void IterateWaypointIndex()
    {
        // Simply selects the next waypoint in the list
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }

        // OPTION FOR IMPROVEMENT: Make the system select a random waypoint everytime IterateWaypointIndex is called
            // SUB-OPTION: Make the system only select a random waypoint within a certain distance of the player, to keep the enemy close to the player
    }

    // Updates where the NavMeshAgent is tracking
    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }
}