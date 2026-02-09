using UnityEngine;

public class PlaySoundOnDamaged : MonoBehaviour
{
    AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnDamaged()
    {
        audioSource.Play();
    }
}
