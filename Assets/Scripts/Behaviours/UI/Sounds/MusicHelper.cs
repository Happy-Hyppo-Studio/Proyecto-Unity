using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHelper : MonoBehaviour
{
    [SerializeField] private AudioClip levelMusic;

    private void Awake()
    {
        Debug.Log(MusicControler.Instance.musicPlaying);
        if (levelMusic != MusicControler.Instance.musicPlaying)
        {
            MusicControler.Instance.PlayOnLoop(levelMusic);
            MusicControler.Instance.musicPlaying = levelMusic;
        }
    }
}
