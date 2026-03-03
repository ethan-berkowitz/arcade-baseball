using UnityEngine;

public class Bat : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip hitSound;

    [SerializeField] private float cooldownTime = 0.2f; // Seconds to wait between sounds
    private float lastPlayTime;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Time.time >= lastPlayTime + cooldownTime)
        {
            audioSource.PlayOneShot(hitSound);
            lastPlayTime = Time.time;
        }
    }
}
