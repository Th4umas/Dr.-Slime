using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player; // Le personnage à suivre
    private float currentYRotation = 0f;
    private bool isRotating = false;

    void Update()
    {
        // Suivre le joueur
        transform.position = player.position;

        // Gestion de la rotation
        if (!isRotating)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(RotateCamera(-90f));
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(RotateCamera(90f));
            }
        }
    }

    private System.Collections.IEnumerator RotateCamera(float angle)
    {
        isRotating = true;
        float targetRotation = currentYRotation + angle;
        float duration = 0.2f; // Temps pour la rotation
        float elapsed = 0f;

        while (elapsed < duration)
        {
            currentYRotation = Mathf.Lerp(currentYRotation, targetRotation, elapsed / duration);
            transform.rotation = Quaternion.Euler(0, currentYRotation, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }

        currentYRotation = targetRotation;
        transform.rotation = Quaternion.Euler(0, currentYRotation, 0);
        isRotating = false;
    }
}