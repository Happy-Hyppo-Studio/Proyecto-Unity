using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GraphicOptionsBehaviour : MonoBehaviour
{
    public TMP_Dropdown resolutionsDropDown;
    public Vector2[] resolutions;
    public int defaultResolution;
    // Start is called before the first frame update
    void Start()
    {
        List<string> options= new List<string>();
        foreach(Vector2 rel in resolutions)
        {
            string option = (int)rel.x+" x "+ (int)rel.y;
            options.Add(option);
        }
        resolutionsDropDown.AddOptions(options);
        resolutionsDropDown.value = defaultResolution;
        resolutionsDropDown.RefreshShownValue();
        resolutionsDropDown.onValueChanged.AddListener((int i) => {
            Screen.SetResolution((int)resolutions[i].x, (int)resolutions[i].y,false);
        });
    }

   
}
