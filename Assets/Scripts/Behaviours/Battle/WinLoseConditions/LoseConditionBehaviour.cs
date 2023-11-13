using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseConditionBehaviour : MonoBehaviour
{
    public GameObject defeatMenu;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0.0f;
        defeatMenu.SetActive(true);
    }
}
