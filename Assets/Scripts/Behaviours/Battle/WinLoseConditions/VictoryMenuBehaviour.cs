using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryMenuBehaviour : MonoBehaviour
{
    public Button continueButton, forfeitButton;
    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(() => {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//Carga el siguiente nivel a este, habria que comprobar que no sea el último
        });
        forfeitButton.onClick.AddListener(() => {
            SceneManager.LoadScene(3);//Carga el selector de nivel
        });

    }

}
