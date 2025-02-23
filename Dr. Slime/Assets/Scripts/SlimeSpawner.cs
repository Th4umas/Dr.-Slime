using UnityEngine;
using UnityEngine.AI;

public class SlimeSpawner : MonoBehaviour
{
    public Slime cannaPrefab;
    public Slime champiPrefab;
    public Slime crackPrefab;

    public int maxCanna = 25, minCanna = 15;
    public int maxChampi = 20, minChampi = 10;
    public int maxCrack = 15, minCrack = 5;

    public float spawnRadius = 20f;
    public LayerMask navMeshLayer;

    void Start()
    {
        SpawnSlimes(cannaPrefab, Random.Range(minCanna, maxCanna));
        SpawnSlimes(champiPrefab, Random.Range(minChampi, maxChampi));
        SpawnSlimes(crackPrefab, Random.Range(minCrack, maxCrack));
    }

    private void SpawnSlimes(Slime slimePrefab, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 spawnPoint = GetRandomNavMeshPosition();
            if (spawnPoint != Vector3.zero)
            {
                Instantiate(slimePrefab, spawnPoint, Quaternion.identity);
            }
        }
    }

    private Vector3 GetRandomNavMeshPosition()
    {
        Vector3 randomPoint = Random.insideUnitSphere * spawnRadius;
        randomPoint.y = 0;  // Keep it on the ground

        if (NavMesh.SamplePosition(randomPoint, out NavMeshHit hit, spawnRadius, NavMesh.AllAreas))
        {
            return hit.position;
        }
        return Vector3.zero;  // If no valid position found, return zero (invalid spawn)
    }
}
