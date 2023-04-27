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

    public Transform player;
    public float triggerDist = 30;
    Vector3 playerVector;
    Vector3 moveDir;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        agent.speed = patrolSpeed;
    }

    void Update()
    {
        playerVector = player.position;
        float playerVectorPosition = playerVector.magnitude;
        moveDir = new Vector3(playerVector.x - agent.transform.position.x, playerVector.y - agent.transform.position.y, playerVector.z - agent.transform.position.z);
        float distToPlayer = moveDir.magnitude;
        if (distToPlayer <= triggerDist)
        {
            agent.SetDestination(playerVector);
            Debug.Log("Chasing Player");
        }
        else
        {
            agent.SetDestination(target);
            Debug.Log("Patroling");
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
    }
}