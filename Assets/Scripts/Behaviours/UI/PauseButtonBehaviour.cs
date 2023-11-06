using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonBehaviour : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(() => {
            pauseMenu.SetActive(true);
            this.gameObject.SetActive(false);
            Time.timeScale = 0.0f;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
