using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchPlate : MonoBehaviour
{
    public GM gameMaster;

    private bool canGoHome = false;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (canGoHome && Input.GetKeyDown("e"))
        {
            SceneManager.LoadScene(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameMaster.rentrerUI = true;
            canGoHome = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameMaster.rentrerUI = false;
            canGoHome = false;
        }
    }
}
