using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinConditionBehaviour : MonoBehaviour
{
    public static event Action callVictory;

    public GameObject[] obj;
    public GameObject winUI;
    public int deathcount = 0;
    public AudioClip sound;
    public event Action winCheck;
    public void Start()
    {
        //chicos, que os haga una clase no significa que sirva siempre
        //en este caso es mejor hacer un evento y usar reacciones
        //DEFINICION DE LA CONDICION DE VICTORIA
        winCheck = new Action(() =>
        {
            //por cada objeto que cheque la victoria, significa que cumplira su condicion
            deathcount++;
            //cuando todos cumplen su condicion
            if (deathcount >= obj.Length)
            {
                //se hace el codigo de victoria
                MusicControler.Instance.StopSound();
                MusicControler.Instance.PlaySound(sound);
                Time.timeScale = 0.0f;
                GameObject pause = GameObject.FindWithTag("BigPause");
                if (pause != null) pause.SetActive(false);
                callVictory?.Invoke();
                winUI.SetActive(true);
            }
        });
        //AÑADIR A LOS OBJETOS CON CONDICION REACTIVA LA REACCION DE VICTORIA
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i] != null)
            {
                obj[i].GetComponent<UnitBehaviour>().deathAction = new Action(() =>
                {
                    winCheck();
                });
            }
        }
        /*
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
        */
    }
}
