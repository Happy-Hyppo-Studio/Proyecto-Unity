using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerChangeSceneBehaviour : MonoBehaviour
{
    public int scene;
    public Counter clock;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(clock.StartCountdown());
        SceneManager.LoadScene(scene);
    }
}
