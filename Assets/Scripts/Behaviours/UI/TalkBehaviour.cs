using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TalkBehaviour : MonoBehaviour
{
    public string[] dialog;
    private int currentDialog=0;
    public GameObject[] image;
    public TMP_Text text;
    public Button nextButton;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0.0f;
        text.text = dialog[currentDialog];
        nextButton.onClick.AddListener(() => 
        {
            currentDialog++;
            if (currentDialog < dialog.Length)
            {
                image[currentDialog].SetActive(true);
                image[currentDialog-1].SetActive(false);
                text.text = dialog[currentDialog];
            }
            else
            {
                Time.timeScale = 1.0f;
                Destroy(this.gameObject);
            }
        });
    }

}
