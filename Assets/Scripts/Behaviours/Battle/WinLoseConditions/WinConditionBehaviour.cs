using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionBehaviour : MonoBehaviour
{
    public GameObject[] objectives;
    public Clock genClock;
    public void Start()
    {
        StartCoroutine(genClock.Cycle(() =>
        {
            for(int i = 0; i < objectives.Length; i++)
            {

            }
        }));
    }
}
