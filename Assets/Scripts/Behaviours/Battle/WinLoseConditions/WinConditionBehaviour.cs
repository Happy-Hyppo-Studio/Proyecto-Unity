using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionBehaviour : MonoBehaviour
{
    public GameObject[] obj;
    public GameObject winUI;
    public Clock genClock;
    public bool win=false;
    public AudioClip sound;
    public void Start()
    {
        StartCoroutine(genClock.Cycle(() =>
        {
            win = true;
            for(int i=0;i<obj.Length; i++)
            {
                if (obj[i] != null)
                    win = false;
            }
            if (win)
            {
                MusicControler.Instance.StopSound();
                MusicControler.Instance.PlaySound(sound);
                Time.timeScale = 0.0f;
                GameObject.FindWithTag("BigPause").SetActive(false);
                winUI.SetActive(true);
            }
        }));
    }
}
