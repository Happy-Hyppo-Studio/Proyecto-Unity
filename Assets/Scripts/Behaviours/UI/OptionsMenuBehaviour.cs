using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuBehaviour : MonoBehaviour
{
    public Button backButton, audioButton, controlsButton;
    public GameObject audioOptions, controlsOptions, pauseMenu;

    void Start()
    {
        backButton.onClick.AddListener(() => {
            GameObject.FindWithTag("OptionsMenu").SetActive(false);
            pauseMenu.SetActive(true);
        });
        audioButton.onClick.AddListener(() => {
            controlsOptions.SetActive(false);
            audioOptions.SetActive(true);
        });
        controlsButton.onClick.AddListener(() => {
            controlsOptions.SetActive(true);
            audioOptions.SetActive(false);
        });
    }

}
