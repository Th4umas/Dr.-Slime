using UnityEngine;
using System.Collections;
using UnityEditor;

public class SlimeSpawner : MonoBehaviour
{
    public Slime cannaPrefab;
    public Slime champiPrefab;
    public Slime crackPrefab;

    public int maxCanna = 25;
    public int minCanna = 15;
    public int maxChampi = 20;
    public int minChampi = 10;
    public int maxCrack = 15;
    public int minCrack = 5;

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
            pos = new Vector3(Random.Range(-15, 15), 0.5f, Random.Range(-15, 15));
            Instantiate(cannaPrefab, pos, Quaternion.identity);
        }

        int randomSpawne = Random.Range(minChampi, maxChampi);

        while (randomSpawne > 0)
        {
            randomSpawne--;
            pos = new Vector3(Random.Range(-20, 20), 0.5f, Random.Range(-20, 20));
            Slime newchampi = Instantiate(champiPrefab, pos, Quaternion.identity);
            newchampi.gameMaster = GetComponent<GM>();
        }

        int randomSpawner = Random.Range(minCrack, maxCrack);

        while (randomSpawner > 0)
        {
            randomSpawner--;
            pos = new Vector3(Random.Range(-20, 20), 0.75f, Random.Range(-20, 20));
            Slime newchampi = Instantiate(crackPrefab, pos, Quaternion.identity);
            newchampi.gameMaster = GetComponent<GM>();
        }

    }

}
