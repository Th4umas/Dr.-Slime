using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Slime : MonoBehaviour
{
    private NavMeshAgent agent;

    public float wanderRadius = 10f;
    public float waitTimeMin = 3f;
    public float waitTimeMax = 6f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Wander());
    }

    private IEnumerator Wander()
    {
        while (true)
        {
            // Pick a random destination within the allowed radius
            Vector3 newPos = GetRandomNavMeshPosition();
            agent.SetDestination(newPos);

            // Wait before moving again
            yield return new WaitForSeconds(Random.Range(waitTimeMin, waitTimeMax));
        }
    }

    private Vector3 GetRandomNavMeshPosition()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, wanderRadius, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return transform.position;  // If no valid position found, stay in place
    }
    public virtual void captured()
    {
        Destroy(gameObject);
    }
}


