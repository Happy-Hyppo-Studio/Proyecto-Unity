using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonBehaviour : MonoBehaviour
{
    public GameObject ageInput, characterInput;
    public TMP_InputField nameInput;
    private TouchScreenKeyboard keyboard;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            //string name = (nameInput.text == "") ? "Anonimo" : nameInput.text;
            //string path = "Assets/profile.txt";
            //StreamWriter sw = new StreamWriter(path);
            //sw.WriteLine(name + " " + characterInput.GetComponent<CharacterSelectBehaviour>().character + " " + ageInput.GetComponent<AgeUIBehaviour>().ageInt);
            //sw.Close();
            SceneManager.LoadScene(2);
        });
        
        nameInput.onSelect.AddListener((str) => {
            if (SystemInfo.deviceType==DeviceType.Handheld&&TouchScreenKeyboard.isSupported)
            {
                keyboard = TouchScreenKeyboard.Open(nameInput.text, TouchScreenKeyboardType.Default);
            }
        });

    }
    private void OnGUI()
    {
        if (SystemInfo.deviceType == DeviceType.Handheld && keyboard != null)
        {
            nameInput.text = keyboard.text;
        }
    }


}
