using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public float followSpeed = 5f;
    public float rotationSpeed = 5f;  // sensi
    public float smoothTime = 0.1f;

    private float yaw = 0f;  // rotation horizontale
    private float pitch = 0f;  // rotation verticale
    public float minPitch = -30f, maxPitch = 60f;

    private float yawVelocity;  // smooth yaw
    private float pitchVelocity;  // smooth pitch

    void LateUpdate()
    {
        // follow smooth
        Vector3 targetPosition = playerTransform.position;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // rotation smooth
        yaw = Mathf.SmoothDampAngle(yaw, yaw + mouseX, ref yawVelocity, smoothTime);

        // limites
        float targetPitch = Mathf.Clamp(pitch - mouseY, minPitch, maxPitch);
        pitch = Mathf.SmoothDamp(pitch, targetPitch, ref pitchVelocity, smoothTime);

        // rotation
        transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
    }
}
