using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AgeUIBehaviour : MonoBehaviour
{
    public TMP_Text ageText;
    public Button ageUp, ageDown;
    public int ageInt;
    // Start is called before the first frame update
    void Start()
    {
        ageUp.onClick.AddListener(() =>
        {
            if (ageInt <= 18) ageInt++;
            ageText.text = (ageInt == 19) ? "+18" : ageInt.ToString();
            globalDataManager.Instance.setEdad(ageInt);
        });
        ageDown.onClick.AddListener(() =>
        {
            if (ageInt >0) ageInt--;
            ageText.text =ageInt.ToString();
            globalDataManager.Instance.setEdad(ageInt);
        });


    }
}
