using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Followed a video tutorial: https://www.youtube.com/watch?v=c8Nq19gkNfs

public class EnemyMovement : MonoBehaviour
{
    // Declaring the variables
    public NavMeshAgent agent;

    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    public float triggerDist = 1;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    void Update()
    {
        // If we are close enough to the waypoint, change to the next waypoint
        if (Vector3.Distance = (target.position, target) < triggerDist)
        {
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
