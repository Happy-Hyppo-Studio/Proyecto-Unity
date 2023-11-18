using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHelper : MonoBehaviour
{
    [SerializeField] private AudioClip levelMusic;

    private void Awake()
    {
        if (levelMusic != null)
        {
            MusicControler.Instance.PlayOnLoop(levelMusic);
        }
        else
        {
            MusicControler.Instance.ResumeSound();
        }
    }
}
