using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject mapping;

    private void Start()
    {
        mapping.SetActive(false);
    }

    public void startButton()
    {
        SceneManager.LoadScene(1);
    }

    public void controllsOn()
    {
        mapping.SetActive(true);
    }
    public void controllsOff()
    {
        mapping.SetActive(false);
    }

    public void exitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in Unity Editor
        #else
            Application.Quit(); // Close the game in a build
        #endif

    }
}
