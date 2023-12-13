using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControler : MonoBehaviour
{
    public static MusicControler Instance;

    private AudioSource audioSource;
    public AudioClip musicPlaying;

    public bool polloPollo;
    //[SerializeField] private AudioClip firstSong;

    private float currentTime;

    private void Awake()
    {
        musicPlaying = null;

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

        musicPlaying = sound;
    }

    public void StopSound()
    {
        audioSource.Stop();
        currentTime = 0;
    }

    /*public void PauseSound()
    {
        currentTime = audioSource.time;
        audioSource.Stop();
    }*/

    public void ResumeSound()
    {
        audioSource.Play();
        audioSource.time = currentTime;
    }
}
