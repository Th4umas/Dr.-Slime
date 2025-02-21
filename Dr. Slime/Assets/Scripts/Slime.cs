using UnityEngine;
using System.Collections;

public class Slime : MonoBehaviour
{
    public float waitTime = 3f;
    public float moveTime = 2f;
    public float moveSpeed = 2f;

    void Start()
    {
        StartCoroutine(MovementLoop());
    }

    private IEnumerator MovementLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);

            StartCoroutine(MoveRandomly());
        }
    }

    private IEnumerator MoveRandomly()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        float startTime = Time.time;

        while (Time.time < startTime + moveTime)
        {
            transform.position += randomDirection * moveSpeed * Time.deltaTime;
            yield return null;
        }
    }

    public void captured()
    {
        Debug.Log("GAH");
        Destroy(gameObject);
    }
}
