using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float rotationStep = 90f;
    private float currentYRotation = 0f;
    public float rotationSpeed = 5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RotateCam(-rotationStep);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            RotateCam(rotationStep);
        }
    }

    private void RotateCam(float angle)
    {
        currentYRotation += angle;
        StartCoroutine(SmoothRotate());
    }

    private System.Collections.IEnumerator SmoothRotate()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(20, currentYRotation, 0);
        float time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, time);
            yield return null;
        }

        transform.rotation = targetRotation;
    }
}
