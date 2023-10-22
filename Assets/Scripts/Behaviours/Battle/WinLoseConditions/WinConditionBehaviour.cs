using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinConditionBehaviour : MonoBehaviour
{
    public GameObject obj1,obj2,obj3;
    public Clock genClock;
    public void Start()
    {
        StartCoroutine(genClock.Cycle(() =>
        {
            if(obj1 == null && obj2 == null && obj3 == null)
            {
                SceneManager.LoadScene(2);
            }
        }));
    }
}
