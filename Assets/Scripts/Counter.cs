using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Counter  //actualizador de tiempo sin bucle
{
    public int currentTime;
    public int maxTime;
    public float SecondsPerTimeUnit;
    public IEnumerator StartCountdown()
    {
        while (currentTime > 0)
        {
            yield return new WaitForSeconds(SecondsPerTimeUnit);
            currentTime--;
        }
    }
}
[System.Serializable]
public class Clock //repetidor de acciones
{
    public float Frequency;
    public IEnumerator Cycle(Action a)
    {
        while(true)
        {
            a();
            yield return new WaitForSeconds(Frequency);
        }             
    }
}
