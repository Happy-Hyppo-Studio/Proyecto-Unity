using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectBehaviour : MonoBehaviour
{
    public string character = "Chico";
    public Image selectedCharacter;
    public Button boy, girl;
    // Start is called before the first frame update
    void Start()
    {
        boy.onClick.AddListener(() => {
            character = "Chico";
            selectedCharacter.GetComponent<RectTransform>().localPosition = boy.transform.localPosition;
        });
        girl.onClick.AddListener(() => {
            character = "Chica";
            selectedCharacter.GetComponent<RectTransform>().localPosition = girl.GetComponent<RectTransform>().localPosition;
        });
    }

}
