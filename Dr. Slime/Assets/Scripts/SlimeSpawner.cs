using UnityEngine;
using System.Collections;
using UnityEditor;

public class SlimeSpawner : MonoBehaviour
{
    public Slime slimePrefab;

    public int maxCanna = 25;
    public int minCanna = 15;

    private Vector3 pos;

    void Start()
    {
        spawn();
    }

    private void spawn()
    {
        int randomSpawn = Random.Range(minCanna, maxCanna);

        while (randomSpawn > 0)
        {
            randomSpawn--;
            pos = new Vector3(Random.Range(-10, 10), 0.5f, Random.Range(-10, 10));
            Instantiate(slimePrefab, pos, Quaternion.identity);
        }

    }

}
