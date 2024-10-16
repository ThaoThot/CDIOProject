using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    private static BackgroundMusicManager instance = null;
    public static BackgroundMusicManager Instance
    {
        get { return instance; }
    }

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
         audioSource = GetComponent<AudioSource>();
    }
     public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }
}