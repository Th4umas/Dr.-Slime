using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object when changing scenes
            GetComponent<AudioSource>().Play(); // Play the music
        }
        else
        {
            Destroy(gameObject); // Prevent duplicate music managers
        }
    }
}
