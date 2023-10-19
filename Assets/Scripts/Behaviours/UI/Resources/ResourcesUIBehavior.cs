using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesUIBehavior : MonoBehaviour
{

    public TextMeshProUGUI recursosWater;
    public TextMeshProUGUI recursosWind;
    public TextMeshProUGUI recursosEarth;
    public TextMeshProUGUI recursosFire;


    // Start is called before the first frame update
    void Start()
    {
        GameObject recursos = GameObject.FindWithTag("Resources");
        recursos.GetComponent<ResourcesManagerBehaviour>().fireHandler += Fire;
        recursos.GetComponent<ResourcesManagerBehaviour>().waterHandler += Water;
        recursos.GetComponent<ResourcesManagerBehaviour>().windHandler += Wind;
        recursos.GetComponent<ResourcesManagerBehaviour>().earthHandler += Earth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Fire(object sender, int recurso)
    {
        recursosFire.text = recurso.ToString();
    }
    private void Water(object sender, int recurso)
    {
        recursosWater.text = recurso.ToString();
    }
    private void Wind(object sender, int recurso)
    {
        recursosWind.text = recurso.ToString();
    }
    private void Earth(object sender, int recurso)
    {
        recursosEarth.text = recurso.ToString();
    }
}
