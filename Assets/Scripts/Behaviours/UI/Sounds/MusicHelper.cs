using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHelper : MonoBehaviour
{
    [SerializeField] private AudioClip levelMusic;

    private void Awake()
    {
        Debug.Log("hola");
        if (levelMusic != MusicControler.Instance.musicPlaying || MusicControler.Instance.musicPlaying == null)
        {
            MusicControler.Instance.PlayOnLoop(levelMusic);
        }
    }
}
