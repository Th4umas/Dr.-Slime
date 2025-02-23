using UnityEngine;
using UnityEngine.AI;

public class SlimeFlee : MonoBehaviour
{
    public float fleeDistance = 5f; // Distance to start fleeing
    public float fleeSpeed = 4f;    // Speed while fleeing
    private Transform player;
    private NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Make sure your player has the tag "Player"
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < fleeDistance)
        {
            FleeFromPlayer();
        }
    }

    void FleeFromPlayer()
    {
        // Calculate flee direction
        Vector3 fleeDirection = (transform.position - player.position).normalized;
        Vector3 fleeTarget = transform.position + fleeDirection * fleeDistance;

        // Move the slime away from the player
        NavMeshHit hit;
        if (NavMesh.SamplePosition(fleeTarget, out hit, fleeDistance, NavMesh.AllAreas))
        {
            agent.speed = fleeSpeed;
            agent.SetDestination(hit.position);
        }
    }
}
