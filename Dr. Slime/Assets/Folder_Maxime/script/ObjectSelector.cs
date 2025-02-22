using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public Camera cam; // La cam�ra principale
    public LayerMask selectableLayer; // Calque des objets s�lectionnables
    private GameObject selectedObject = null;
    private Vector3 originalPosition;
    public float liftHeight = 0.5f; // Hauteur � laquelle l'objet est soulev�

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Clic gauche
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f, selectableLayer))
            {
                SelectObject(hit.collider.gameObject);
            }
            else
            {
                DeselectObject();
            }
        }
    }

    void SelectObject(GameObject obj)
    {
        if (selectedObject != null)
        {
            DeselectObject(); // R�initialiser l'ancien objet s�lectionn�
        }

        selectedObject = obj;
        originalPosition = obj.transform.position;
        obj.transform.position += Vector3.up * liftHeight; // Soul�ve l'objet

        Debug.Log("Objet s�lectionn� : " + obj.name);
    }

    void DeselectObject()
    {
        if (selectedObject != null)
        {
            selectedObject.transform.position = originalPosition; // R�tablir la position initiale
            selectedObject = null;
        }
    }
}