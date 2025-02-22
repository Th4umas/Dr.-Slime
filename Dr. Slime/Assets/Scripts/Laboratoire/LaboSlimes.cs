using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class LaboSlimes : MonoBehaviour
{
    private Vector3 startPosition;
    public SlimeContainer container;

    public float hoverHeight = 0.2f;
    public float hoverSpeed = 5f;

    private static LaboSlimes selectedSlime = null;
    private bool isSelected = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnMouseEnter()
    {
        if (selectedSlime != null && selectedSlime != this) return;

        if (!isSelected)
        {
            StopAllCoroutines();
            StartCoroutine(MoveObject(transform.position, startPosition + new Vector3(0, hoverHeight, 0)));
        }
    }

    private void OnMouseExit()
    {
        if (!isSelected)
        {
            StopAllCoroutines();
            StartCoroutine(MoveObject(transform.position, startPosition));
        }
    }

    private void OnMouseDown()
    {
        if (isSelected)
        {
            isSelected = false;
            selectedSlime = null;
            StopAllCoroutines();
            StartCoroutine(MoveObject(transform.position, startPosition));
        }
        else
        {
            if (selectedSlime != null)
            {
                selectedSlime.Deselect();
            }

            isSelected = true;
            selectedSlime = this;
            StopAllCoroutines();
            StartCoroutine(MoveObject(transform.position, startPosition + new Vector3(0, hoverHeight, 0)));

            if (container != null)
            {
                container.AddSlime(gameObject);
            }
        }
    }

    public void Deselect()
    {
        isSelected = false;
        StopAllCoroutines();
        StartCoroutine(MoveObject(transform.position, startPosition));
    }

    private IEnumerator MoveObject(Vector3 from, Vector3 to)
    {
        float elapsedTime = 0f;
        while (elapsedTime < 1f)
        {
            transform.position = Vector3.Lerp(from, to, elapsedTime);
            elapsedTime += Time.deltaTime * hoverSpeed;
            yield return null;
        }
        transform.position = to;
    }
}
