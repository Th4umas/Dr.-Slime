using UnityEngine;
using System.Collections;

public class recipe : MonoBehaviour
{
    private bool looking = false;
    private bool canflip = false;

    public GameObject cam;


    private void Start()
    {
        cam.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            stopview();
        }
    }

    IEnumerator SmoothFlip(float duration)
    {
        canflip = false;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = transform.rotation * Quaternion.Euler(0, 0, 180);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        canflip = true;
    }

    void StartFlip()
    {
        if (canflip)
        {
            StartCoroutine(SmoothFlip(0.2f));
        }
    }

    private void OnMouseDown()
    {
        if (!looking)
        {
            focus();
        }
        else
        {
            StartFlip();    
        }

    }

    private void focus()
    {
        cam.SetActive (true);
        canflip = true;
        looking = true;
    }

    private void stopview()
    {
        cam.SetActive(false);
        canflip = false;
        looking = false;
    }

}
