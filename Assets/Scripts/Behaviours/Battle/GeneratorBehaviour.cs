using UnityEngine;
public class GeneratorBehaviour : MonoBehaviour
{
    public Clock genClock;
    public elements element;
    public void Start()
    {
        ResourcesManagerBehaviour resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<ResourcesManagerBehaviour>();
        StartCoroutine(genClock.Cycle(() =>
        {
            //codigo de generador
            resources.ResourceChange(1, element);
        }));
    }
}