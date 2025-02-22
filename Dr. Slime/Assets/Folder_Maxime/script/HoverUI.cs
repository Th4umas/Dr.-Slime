using UnityEngine;
using UnityEngine.UI;

public class HoverUI : MonoBehaviour
{
    public Camera cam; // Caméra principale
    public LayerMask selectableLayer; // Calque des objets sélectionnables
    public Text hoverText; // Référence au texte UI (Legacy UI)

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f, selectableLayer))
        {
            ShowText(true);
        }
        else
        {
            ShowText(false);
        }
    }

    void ShowText(bool show)
    {
        hoverText.gameObject.SetActive(show);
    }
}