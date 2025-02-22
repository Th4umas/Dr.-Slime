using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class SlimeContainer : MonoBehaviour
{
    private MeshRenderer m_MeshRenderer;

    private int slimeCount = 0;
    private string slimeType = "None";

    public List<int> fluids = new List<int>();

    public GameObject finished;

    private void Start()
    {
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
        slimeCount++;

        if (slime.GetComponent<LaboCanna>() != null)
        {
            slimeType = "CannaContainer";
            fluids.Add(1);
        }
        else if (slime.GetComponent<LaboChampi>() != null)
        {
            slimeType = "ChampiContainer";
            fluids.Add(2);
        }
        else if (slime.GetComponent<LaboCrack>() != null)
        {
            slimeType = "CrackContainer";
            fluids.Add(3);
        }

        Debug.Log("Slime added! Total count: " + slimeCount + " | Last Slime Type: " + slimeType);
    }

    private void Update()
    {
        if(slimeCount ==1)
        {
            m_MeshRenderer.material.color = Color.blue;
        }

        if(slimeCount == 3)
        {
            //fluidcheck(fluids);
            m_MeshRenderer.material.color = Color.red;
            Instantiate(finished, transform.position, Quaternion.identity);
        }
    }

    //when the container has three ingredients, it either blows up or becomes something sellable
    /*
    public bool fluidcheck(List l)
    {
        for (int i = 0) ;
        {
            
        }
        return false;
    }*/
}
