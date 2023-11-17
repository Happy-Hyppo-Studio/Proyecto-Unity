using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterRangerBehaviour : MonoBehaviour
{
    UnitBehaviour unit;
    public Clock shootClock;
    public GameObject[] bullets;
    public void Start()
    {
        int i = 0;
        unit = GetComponent<UnitBehaviour>();
        Vector3 spawnPoint = (unit.isAlly) ? this.transform.position + new Vector3(1, 0, 0) : this.transform.position + new Vector3(-1, 0, 0);
        StartCoroutine(shootClock.Cycle(() =>
        {
            //codigo de generador
            Instantiate(bullets[i%bullets.Length], spawnPoint, Quaternion.identity);
            i++;
        }));
    }
}
