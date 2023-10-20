using UnityEngine;
public class FactoryBehaviour : MonoBehaviour
{
    public Clock genClock;
    public void Start()
    {
        ResourcesManagerBehaviour resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<ResourcesManagerBehaviour>();
        element unitElement = GetComponent<UnitBehaviour>().type;
        StartCoroutine(genClock.Cycle(() =>
        {
            //codigo de generador
            resources.ResourceChange(1, unitElement);
        }));
    }
}