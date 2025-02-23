using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SlimeContainer : MonoBehaviour
{
    private MeshRenderer m_MeshRenderer;

    private string slimeType = "None";

    public int numéro = 0;

    public List<int> fluids = new List<int>();

    public GameObject finished;
    public GameObject pour;

    public GameObject box;
    private Transform boxTransform;

    private Vector3 becherOriginalPosition;

    private Transform becherTransform;

    public Transform bechertopTransform;

    public Transform becherwaypoint;
    public Transform boxwaypoint;

    public Transform becherrightTransform;

    private Vector3 boxOriginalPosition;

    public bool canAdd = true;

    private void Start()
    {
        becherTransform = transform;
        boxTransform = box.transform;
        boxOriginalPosition = box.transform.position;  // Store the box's original position
        becherOriginalPosition = becherTransform.position; // Store the beaker's original position
        m_MeshRenderer = GetComponent<MeshRenderer>();
    }



    private void OnMouseDown()
    {
        if (LaboSlimes.selectedSlime != null)
        {
            AddSlime(LaboSlimes.selectedSlime.gameObject);
            LaboSlimes.selectedSlime.Deselect();
        }
    }

    public void AddSlime(GameObject slime)
    {
        if (canAdd)
        {
            if (slime.GetComponent<LaboCanna>() != null)
            {
                if(data.cannabis > 0)
                {
                    slimeType = "CannaContainer";
                    fluids.Add(1);
                    data.cannabis--;
                    Debug.Log("Slime added! Total count: " + fluids.Count + " | Last Slime Type: " + slimeType);
                    GameObject caca = Instantiate(pour, transform.position, Quaternion.identity);
                    Destroy(caca, 3f);
                }

            }
            else if (slime.GetComponent<LaboChampi>() != null)
            {
                if (data.champignons > 0)
                {
                    slimeType = "ChampiContainer";
                    fluids.Add(2);
                    data.champignons--;
                    Debug.Log("Slime added! Total count: " + fluids.Count + " | Last Slime Type: " + slimeType);
                    GameObject caca = Instantiate(pour, transform.position, Quaternion.identity);
                    Destroy(caca, 3f);
                }

            }
            else if (slime.GetComponent<LaboCrack>() != null)
            {
                if (data.crack > 0)
                {
                    slimeType = "CrackContainer";
                    fluids.Add(3);
                    data.crack--;
                    Debug.Log("Slime added! Total count: " + fluids.Count + " | Last Slime Type: " + slimeType);
                    GameObject caca = Instantiate(pour, transform.position, Quaternion.identity);
                    Destroy(caca, 3f);
                }

            }

        }





        if (fluids.Count == 2)
        {
            //StartCoroutine(packup());
            canAdd = false;
        }
    }
    public IEnumerator packup()
    {
        float moveSpeed = 5f; // Adjust movement speed as needed

        // Instantiate the finished product and destroy it after 3 seconds
        GameObject caca = Instantiate(finished, transform.position, Quaternion.identity);
        Destroy(caca, 3f);
        yield return new WaitForSeconds(1f);

        // Move the beaker towards the "becherwaypoint" inside the box
        yield return StartCoroutine(MoveObject(becherTransform, becherwaypoint.position, moveSpeed));

        // Move the box and beaker together toward the "boxwaypoint"
        yield return StartCoroutine(MoveObject(boxTransform, boxwaypoint.position, moveSpeed));


        yield return StartCoroutine(MoveObject(becherTransform, becherrightTransform.position, moveSpeed));

        // Process the contents and reset the container
        Lethal(fluids);
        fluids.Clear();
        yield return new WaitForSeconds(1f);

        // Move the box back to its original position (fix applied here)
        yield return StartCoroutine(MoveObject(boxTransform, boxOriginalPosition, moveSpeed));

        // Move the beaker up to "bechertopTransform"
        yield return StartCoroutine(MoveObject(becherTransform, bechertopTransform.position, moveSpeed));

        // Move the beaker back down to its original position
        yield return StartCoroutine(MoveObject(becherTransform, becherOriginalPosition, moveSpeed));

        Debug.Log("Beaker and box returned to original positions smoothly!");
    }



    private IEnumerator MoveObject(Transform obj, Vector3 targetPosition, float speed)
    {
        Vector3 startPosition = obj.position;
        float distance = Vector3.Distance(startPosition, targetPosition);
        float elapsedTime = 0f;

        while (elapsedTime < distance / speed) // Ensures movement time scales with distance
        {
            obj.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime / (distance / speed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.position = targetPosition; // Snap to final position to avoid precision errors
    }




    //calculates the money
    public void Lethal(List<int> l)
    {
        int count2 = 0;
        int count3 = 0;
        int transaction = 0;


        foreach (int num in l)
        {
            if (num == 1)
            {
                transaction += 50;
            }
            if (num == 2)
            {
                count2++;
                transaction += 100;
            }

            if (num == 3)
            {
                count3++;
                transaction += 200;
            }

            if (count2 >= 3 || count3 >= 2)
            {
                Debug.Log("lethal");
                data.money -= transaction / 2;
                return;
            }
        }
        data.money += transaction;
        Debug.Log("you good");
    }
}