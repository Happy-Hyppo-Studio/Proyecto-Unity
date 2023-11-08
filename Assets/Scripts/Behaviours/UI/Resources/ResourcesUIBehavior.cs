using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourcesUIBehavior : MonoBehaviour
{

    public TextMeshProUGUI waterCountText;
    public TextMeshProUGUI airCountText;
    public TextMeshProUGUI earthCountText;
    public TextMeshProUGUI fireCountText;


    // Start is called before the first frame update
    void Start()
    {
        GameObject recursos = GameObject.FindWithTag("Resources");
        waterCountText.text = recursos.GetComponent<ResourcesManagerBehaviour>().resources[0].ToString();
        airCountText.text = recursos.GetComponent<ResourcesManagerBehaviour>().resources[0].ToString();
        earthCountText.text = recursos.GetComponent<ResourcesManagerBehaviour>().resources[0].ToString();
        fireCountText.text = recursos.GetComponent<ResourcesManagerBehaviour>().resources[0].ToString();
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
        fireCountText.text = recurso.ToString();
    }
    private void Water(object sender, int recurso)
    {
        waterCountText.text = recurso.ToString();
    }
    private void Wind(object sender, int recurso)
    {
        airCountText.text = recurso.ToString();
    }
    private void Earth(object sender, int recurso)
    {
        earthCountText.text = recurso.ToString();
    }
}
