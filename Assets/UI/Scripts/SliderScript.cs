using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public TextMeshProUGUI edadText;
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(value =>
        {
            edadText.text = slider.value.ToString();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
