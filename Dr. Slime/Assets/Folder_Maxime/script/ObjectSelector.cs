using UnityEngine;

public class ObjectSelector : MonoBehaviour
{
    public Camera cam; // La caméra principale
    public LayerMask selectableLayer; // Calque des objets sélectionnables
    private GameObject selectedObject = null;
    private Vector3 originalPosition;
    public float liftHeight = 0.5f; // Hauteur à laquelle l'objet est soulevé

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
            DeselectObject(); // Réinitialiser l'ancien objet sélectionné
        }

        selectedObject = obj;
        originalPosition = obj.transform.position;
        obj.transform.position += Vector3.up * liftHeight; // Soulève l'objet

        Debug.Log("Objet sélectionné : " + obj.name);
    }

    void DeselectObject()
    {
        if (selectedObject != null)
        {
            selectedObject.transform.position = originalPosition; // Rétablir la position initiale
            selectedObject = null;
        }
    }
}