using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuBehaviour : MonoBehaviour
{
    public Button continueButton, optionsButton, forfeitButton;
    public GameObject optionsMenu, pauseButton;
    
    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(() => {
            Time.timeScale = 1.0f;
            pauseButton.SetActive(true);
            GameObject.FindWithTag("PauseMenu").SetActive(false);
        });
        optionsButton.onClick.AddListener(() => {
            optionsMenu.SetActive(true);
        });
        forfeitButton.onClick.AddListener(() => {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(3);
        });

    }

}
