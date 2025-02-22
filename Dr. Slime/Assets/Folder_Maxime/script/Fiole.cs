using System.Collections.Generic;
using UnityEngine;

public class Fiole : MonoBehaviour
{
    private List<GameObject> slimes = new List<GameObject>(); // Liste des slimes dans la fiole
    private Renderer fioleRenderer; // Renderer de la fiole

    void Start()
    {
        fioleRenderer = GetComponent<Renderer>(); // Récupérer le renderer de la fiole
    }

    public void AddSlime(GameObject slime)
    {
        if (!slimes.Contains(slime))
        {
            slimes.Add(slime);
            UpdateFioleColor();
        }
    }

    private void UpdateFioleColor()
    {
        if (slimes.Count == 0) return;

        // Initialisation de la couleur finale (commence avec du noir, pas de couleur définie)
        Color finalColor = Color.black;
        int validSlimes = 0; // Compter les slimes valides

        // Parcours de tous les slimes pour fusionner leur couleur
        foreach (GameObject slime in slimes)
        {
            if (slime != null) // Vérifie si le slime est encore valide
            {
                Renderer slimeRenderer = slime.GetComponent<Renderer>();
                if (slimeRenderer != null)
                {
                    Color slimeColor = slimeRenderer.material.color;

                    // Additionner la couleur du slime
                    finalColor += slimeColor;
                    validSlimes++; // Compter le slime valide
                }
            }
        }

        // Si des slimes valides ont été trouvés, on fusionne leurs couleurs
        if (validSlimes > 0)
        {
            finalColor /= validSlimes; // Faire la moyenne des couleurs (fusion)
            fioleRenderer.material.color = finalColor; // Appliquer la couleur calculée à la fiole

            Debug.Log("Couleur de la fiole fusionnée : " + finalColor); // Debug pour voir la couleur résultante
        }
    }
}
