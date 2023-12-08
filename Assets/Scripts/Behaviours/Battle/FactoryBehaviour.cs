using UnityEngine;
using UnityEngine.SceneManagement;
public class FactoryBehaviour : MonoBehaviour
{
    public Clock genClock;
    private bool fireWeakened;
    public void Start()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        if (scene >= 1)
        {
            fireWeakened = true;
        }

        ResourcesManagerBehaviour resources = GameObject.FindGameObjectWithTag("Resources").GetComponent<ResourcesManagerBehaviour>();
        element unitElement = GetComponent<UnitBehaviour>().type;
        if (fireWeakened && unitElement == element.water)
        {
            genClock.Frequency = 2;
        }
        StartCoroutine(genClock.Cycle(() =>
        {
            //codigo de generador
            resources.ResourceChange(1, unitElement);
            
        }));
    }
}