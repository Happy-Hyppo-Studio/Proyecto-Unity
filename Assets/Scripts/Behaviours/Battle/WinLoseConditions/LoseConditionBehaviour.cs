using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LoseConditionBehaviour : MonoBehaviour
{

    public static Action callDefeat;

    public GameObject defeatMenu;
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MusicControler.Instance.StopSound();
        MusicControler.Instance.PlaySound(sound);
        Time.timeScale = 0.0f;
        GameObject.FindWithTag("BigPause").SetActive(false);
        callDefeat?.Invoke();
        defeatMenu.SetActive(true);
    }
}
