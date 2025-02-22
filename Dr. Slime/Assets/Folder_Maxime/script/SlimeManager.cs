using UnityEngine;

public class SlimeManager : MonoBehaviour
{
    public Camera cam;
    public LayerMask slimeLayer;
    public LayerMask fioleLayer;

    private GameObject selectedSlime = null;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Clic gauche
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, slimeLayer))
            {
                SelectSlime(hit.collider.gameObject);
            }
            else if (Physics.Raycast(ray, out hit, 100f, fioleLayer) && selectedSlime != null)
            {
                Fiole fiole = hit.collider.GetComponent<Fiole>();
                if (fiole != null)
                {
                    fiole.AddSlime(selectedSlime);
                    selectedSlime = null; // D�s�lectionner apr�s ajout
                }
            }
        }
    }

    void SelectSlime(GameObject slime)
    {
        selectedSlime = slime;
        Debug.Log("Slime s�lectionn� : " + slime.name);
    }
}
