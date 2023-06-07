using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip tapSound;
    [SerializeField]
    private AudioClip deathSound;

    void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }

        instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayTap()
    {
        audioSource.PlayOneShot(tapSound, 1f);
    }

    public void PlayDeath()
    {
        audioSource.PlayOneShot(deathSound, 1f);
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
