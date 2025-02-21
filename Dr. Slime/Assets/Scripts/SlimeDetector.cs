using System.Collections.Generic;
using UnityEngine;

public class SlimeDetector : MonoBehaviour
{
    public Transform Player;  
    public GameObject FocusSlime;

    public GM gameMaster;

    private HashSet<GameObject> detectedSlimes = new HashSet<GameObject>();  

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

        if(FocusSlime != null)
        {
            gameMaster.captureUI = true;

            if (Input.GetKeyDown("space"))
            {
                Slime slimeScript = FocusSlime.GetComponent<Slime>();
                if (slimeScript != null)
                {
                    slimeScript.captured();
                    gameMaster.capture(1);
                }
            }
        }
        else
        {

            gameMaster.captureUI = false;
        }

    }

    void FindClosestSlime()
    {
        float closestDistance = Mathf.Infinity;
        GameObject closestSlime = null;

        foreach (GameObject slime in detectedSlimes)
        {
            if (slime == null) continue;  

            float distance = Vector3.Distance(Player.position, slime.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestSlime = slime;
            }
        }
         
        FocusSlime = closestSlime;
    }
}
