using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepController : MonoBehaviour
{
    public AudioClip[] footstepSounds; // Array von Schrittgeräuschen
    private AudioSource audioSource;
    private CharacterController characterController;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded && characterController.velocity.magnitude > 2f && !audioSource.isPlaying)
        {
            PlayFootstepSound();
        }
    }

    void PlayFootstepSound()
    {
        int n = Random.Range(1, footstepSounds.Length);
        audioSource.clip = footstepSounds[n];
        audioSource.PlayOneShot(audioSource.clip);
        // Tausche das verwendete Geräusch mit dem ersten in der Liste
        footstepSounds[n] = footstepSounds[0];
        footstepSounds[0] = audioSource.clip;
    }
}
