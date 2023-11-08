using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuBehaviour : MonoBehaviour
{
    public Button backButton, audioButton, controlsButton;
    public GameObject audioOptions, controlsOptions;

    void Start()
    {
        backButton.onClick.AddListener(() => {
            GameObject.FindWithTag("OptionsMenu").SetActive(false);
        });
        audioButton.onClick.AddListener(() => {
            audioOptions.SetActive(true);
            controlsOptions.SetActive(false);
        });
        controlsButton.onClick.AddListener(() => {
            controlsOptions.SetActive(true);
            audioOptions.SetActive(false);
        });
    }

}
