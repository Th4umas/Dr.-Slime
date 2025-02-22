using UnityEngine;

public class SlimeContainer : MonoBehaviour
{
    private MeshRenderer m_MeshRenderer;

    private int slimeCount = 0;
    private string slimeType = "None";

    private void Start()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnMouseDown()
    {
        if (LaboSlimes.selectedSlime != null) // Check if a slime is selected
        {
            AddSlime(LaboSlimes.selectedSlime.gameObject);
            LaboSlimes.selectedSlime.Deselect(); // Deselect the slime after adding it
        }
    }

    public void AddSlime(GameObject slime)
    {
        slimeCount++;

        if (slime.GetComponent<LaboCanna>() != null)
        {
            slimeType = "CannaContainer";
        }
        else if (slime.GetComponent<LaboChampi>() != null)
        {
            slimeType = "ChampiContainer";
        }
        else if (slime.GetComponent<LaboCrack>() != null)
        {
            slimeType = "CrackContainer";
        }

        Debug.Log("Slime added! Total count: " + slimeCount + " | Last Slime Type: " + slimeType);
    }

    private void Update()
    {
        if(slimeCount > 0)
        {
            m_MeshRenderer.material.color = Color.blue;
        }
    }
}
