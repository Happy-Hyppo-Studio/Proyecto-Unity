using UnityEngine;
public class GeneratorBehaviour : MonoBehaviour
{
    Clock genClock;
    public void Start()
    {
        StartCoroutine(genClock.Cycle(() =>
        {
            //codigo de generador
        }));
    }
}