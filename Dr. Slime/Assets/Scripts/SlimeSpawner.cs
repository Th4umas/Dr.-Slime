using UnityEngine;
using System.Collections;
using UnityEditor;

public class SlimeSpawner : MonoBehaviour
{
    public Slime slimePrefab;

    public int max = 25;
    public int min = 15;

    private Vector3 pos;
    private float randomx;
    private float randomz;

    void Start()
    {


        spawn();
    }

    void Update()
    {
        
    }

    private void spawn()
    {
        int randomSpawn = Random.Range(min, max);

        while (randomSpawn > 0)
        {
            randomSpawn--;
            randomx = Random.Range(-10, 10);
            randomz = Random.Range(-10, 10);

            pos = new Vector3(randomx, 0.5f, randomz);
            Instantiate(slimePrefab, pos, Quaternion.identity);
        }

    }

}
