using UnityEngine;
using System.Collections;

public class SlimeController : MonoBehaviour
{
    public float waitTimemin = 3f;
    public float waitTimemax = 5f;
    public float moveTimeMin = 1f; 
    public float moveTimeMax = 3f; 
    public float moveSpeedMin = 1f;
    public float moveSpeedMax = 3f;

    public GM gameMaster;

    void Start()
    {
        StartCoroutine(MovementLoop());

        gameMaster = GetComponent<GM>();
    }

    private IEnumerator MovementLoop()
    {
        yield return new WaitForSeconds(Random.Range(0f, 3f));

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(waitTimemin, waitTimemax));

            StartCoroutine(MoveRandomly());
        }
    }

    private IEnumerator MoveRandomly()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        float randomMoveTime = Random.Range(moveTimeMin, moveTimeMax); 
        float randomSpeed = Random.Range(moveSpeedMin, moveSpeedMax);  

        float startTime = Time.time;

        while (Time.time < startTime + randomMoveTime)
        {
            transform.position += randomDirection * randomSpeed * Time.deltaTime;
            yield return null;
        }
    }

    public virtual void captured()
    {
        StartCoroutine (capture(1));

    }

    public IEnumerator capture(int type)
    {
        Destroy(gameObject, 1f);
        yield return new WaitForSeconds(.9f);
        gameMaster.capture(type);
    }
}