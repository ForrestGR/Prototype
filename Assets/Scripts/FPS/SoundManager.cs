using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private AudioSource audioSource;

    [SerializeField] private AudioClip attackSound;
    [SerializeField] private AudioClip followSound;
    [SerializeField] private AudioClip[] wanderSounds;

    [SerializeField] private float minWanderSoundInterval = 5.0f;
    [SerializeField] private float maxWanderSoundInterval = 15.0f;
    private float nextWanderSoundTime;


    private AudioClip currentClip;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Methode zum Abspielen von Sounds
    public void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            if (audioSource.isPlaying && currentClip == clip)
                return;

            audioSource.PlayOneShot(clip);
            currentClip = clip;
        }
    }

    // Methode zum Abspielen des Angriffssounds
    public void PlayAttackSound()
    {
        PlaySound(attackSound);
    }

    public void PlayFollowSound()
    {
        PlaySound(followSound);
    }

    public void PlayRandomWanderSound()
    {
        if (Time.time >= nextWanderSoundTime)
        {
            if (wanderSounds.Length > 0)
            {
                AudioClip randomWanderSound = wanderSounds[Random.Range(0, wanderSounds.Length)];
                PlaySound(randomWanderSound);
            }
            nextWanderSoundTime = Time.time + Random.Range(minWanderSoundInterval, maxWanderSoundInterval);
        }
    }
}
