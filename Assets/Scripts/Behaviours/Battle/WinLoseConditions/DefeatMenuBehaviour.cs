using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DefeatMenuBehaviour : MonoBehaviour
{
    public Button continueButton, forfeitButton;
    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(() => {
            Time.timeScale = 1.0f;
            MusicControler.Instance.StopSound();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Carga el siguiente nivel a este, habria que comprobar que no sea el último
        });
        forfeitButton.onClick.AddListener(() => {
            Time.timeScale = 1.0f;
            MusicControler.Instance.StopSound();
            SceneManager.LoadScene(3);//Carga el selector de nivel
        });
    }
}
