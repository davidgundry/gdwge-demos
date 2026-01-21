using UnityEngine;

public class PlaySoundOnSpawn : MonoBehaviour
{
    AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void OnSpawn()
    {
        audioSource.Play();
    }
}
