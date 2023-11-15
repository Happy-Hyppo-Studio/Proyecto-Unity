using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseConditionBehaviour : MonoBehaviour
{
    public GameObject defeatMenu;
    public AudioClip sound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EffectsControler.Instance.PlaySound(sound);
        Time.timeScale = 0.0f;
        defeatMenu.SetActive(true);
    }
}
