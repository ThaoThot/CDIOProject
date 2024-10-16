using UnityEngine;

public class MusicBG : MonoBehaviour
{
    private static MusicBG instance = null;
    public static MusicBG Instance
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

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();  
        }
    }

     public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void StartMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();  
        }
    }
}