using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UITimer : MonoBehaviour
{
    public static UITimer instance; // Singleton instance

    public float timeRemaining = 300f;  // 5 minutes
    public TextMeshProUGUI timerText;
    private bool timerRunning = true;

    void Awake()
    {
        // Singleton pattern to ensure only one instance exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Keeps it across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    void Update()
    {
        if (timerRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else if (timeRemaining <= 0)
        {
            timerRunning = false;
            timeRemaining = 0;
            timerText.text = "00:00";
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    // Function to change scenes
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
