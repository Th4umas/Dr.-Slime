using System.Collections.Generic;
using UnityEngine;

public class SlimeDetector : MonoBehaviour
{
    public Transform Player;  // Assign player here
    public GameObject FocusSlime;  // The closest slime

    private HashSet<GameObject> detectedSlimes = new HashSet<GameObject>();  // Stores slimes in range

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Slime"))
        {
            detectedSlimes.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Slime"))
        {
            detectedSlimes.Remove(other.gameObject);

            // If the removed slime was the focus, update the closest slime
            if (FocusSlime == other.gameObject)
            {
                FocusSlime = null;
                FindClosestSlime();
            }
        }
    }

    void Update()
    {
        FindClosestSlime();
    }

    void FindClosestSlime()
    {
        float closestDistance = Mathf.Infinity;
        GameObject closestSlime = null;

        foreach (GameObject slime in detectedSlimes)
        {
            if (slime == null) continue;  // Skip destroyed slimes

            float distance = Vector3.Distance(Player.position, slime.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestSlime = slime;
            }
        }

        // Set FocusSlime to the closest slime found
        FocusSlime = closestSlime;
    }
}
