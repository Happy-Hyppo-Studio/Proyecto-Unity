using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsControler : MonoBehaviour
{
    public static EffectsControler Instance;

    private AudioSource audioSource;
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
    }

    public void PlaySound(AudioClip sound)
    {
        audioSource.PlayOneShot(sound);
    }
}

