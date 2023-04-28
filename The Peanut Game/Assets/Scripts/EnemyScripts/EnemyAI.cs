using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Followed a video tutorial: https://www.youtube.com/watch?v=c8Nq19gkNfs
// The video was a part of it, the chasing part was mine

public class EnemyAI : MonoBehaviour
{
    // Declaring the variables
    public NavMeshAgent agent;

    // Waypoint variables
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 target;

    // Chase variables
    [SerializeField] float patrolSpeed = 200;
    [SerializeField] float chaseSpeed = 300;

    // Player Variables
    public Transform player;
    public float triggerDist = 500;
    Vector3 playerVector;
    Vector3 moveDir;

    // Sets some variables, like the agent component, the enemy speed, and the first waypoint
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = patrolSpeed;
        UpdateDestination();
    }

    void Update()
    {
        // Logic to convert the player's position into a Vector3 that spans from the enemy to the player
        playerVector = player.position;
        float playerVectorPosition = playerVector.magnitude;
        moveDir = new Vector3(playerVector.x - agent.transform.position.x, playerVector.y - agent.transform.position.y, playerVector.z - agent.transform.position.z);
        float distToPlayer = moveDir.magnitude;
        // If the player is within range, chase the player
        if (distToPlayer <= triggerDist)
        {
            agent.SetDestination(playerVector);
            agent.speed = chaseSpeed;
            Debug.Log("Chasing Player");
        }
        // ...Or if they aren't, go to the next waypoint
        else
        {
            agent.SetDestination(target);
            agent.speed = patrolSpeed;
            Debug.Log("Patroling");
        }
        // If we are close enough to the waypoint, change to the next waypoint
        // OPTION: I could nest this If statement into the else statement above, which would not update
        // the waypoints when the enemy is chasing the player. I'm not sure; more testing required.
        // If I do, nest it above all code currently in the statement. (from the agent.SetDestination up)
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
            /* This part is commented out because it doesn't fit the theme, but I might want it when I save the script.
            Instead, we're going to have the monster gain an extremely aware sense after finishing 21 waypoints, 
            Gaining exact knowledge of where the player is (and being permenantly set to chase mode)
            This will help put the pressure on players that juked him out or are dawdling and trying to get all the collectibles. Heh heh heh...*/
            
            //waypointIndex = 0;
            triggerDist = 99999999;
        }

        // OPTION: Make the system select a random waypoint everytime IterateWaypointIndex is called
        // SUB-OPTION: Make the system only select a random waypoint within a certain distance of the
        // player, to keep the enemy close to the player
    }

    // Updates where the NavMeshAgent is tracking
    // *NOTE* the tutorial shows the Agent's destination set here; I did that in Update
    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position;
    }
}