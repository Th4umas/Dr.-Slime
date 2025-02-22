using UnityEngine;

public class SlimeContainer : MonoBehaviour
{
    private int slimeCount = 0;
    private string slimeType = "None";

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
}
