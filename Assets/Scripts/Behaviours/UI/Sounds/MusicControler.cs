using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControler : MonoBehaviour
{
    public static MusicControler Instance;

    private AudioSource audioSource;
    //[SerializeField] private AudioClip firstSong;

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

        //PlayOnLoad(firstSong);
        //audioSource.Play(0);
    }

    public void PlayOnLoop(AudioClip levelMusic)
    {
        audioSource.loop = true;
        audioSource.clip = levelMusic;
        audioSource.Play();
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
        currentTime = audioSource.time;
        audioSource.Stop();
    }

    public void ResumeSound()
    {
        audioSource.Play();
        audioSource.time = currentTime;
    }
}
