using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControler : MonoBehaviour
{
    public static MusicControler Instance;

    private AudioSource audioSource;
    [SerializeField] private AudioClip levelMusic;

    private float currentTime;

    private void Awake()
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

        audioSource = GetComponent<AudioSource>();

        audioSource.clip = levelMusic;
        //audioSource.Play(0);
    }

    public void PlaySound(AudioClip sound)
    {
        audioSource.Stop();

        audioSource.PlayOneShot(sound);
    }

    public void StopSound()
    {
        audioSource.Stop();
        currentTime = 0;
    }

    public void PauseSound()
    {
        audioSource.Play();
        audioSource.time = currentTime;
    }

    public void ResumeSound()
    {
        currentTime = audioSource.time;
        audioSource.Stop();
    }
}
