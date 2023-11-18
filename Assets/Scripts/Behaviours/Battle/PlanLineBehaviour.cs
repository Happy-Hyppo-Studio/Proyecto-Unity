using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanLineBehaviour : MonoBehaviour
{
    [System.Serializable]
    public struct formationUnit
    {
        public GameObject enemy;
        public float secondsSincePrevious;
    }
    //SI TENEIS UNA IDEA QUE PENSAIS ES MAS RENTABLE PARA LA CREACION DE NIVELES NO DUDEIS EN EXPERIMENTARLA, ESTA ES LA QUE OS PUEDO DEJAR COMO TEMPLATE
    public formationUnit[] formation;
    private void Start()
    {
        StartCoroutine(roundLoop());
    }
    /*
    // Update is called once per frame
    void Update()//mucha pereza ahora para hacer corrutinas, optimizare mas tarde
    {
        if (Time.timeSinceLevelLoad > timeOffsets[i] && i < timeOffsets.Length -1)
        {
            Instantiate(enemy[i%enemy.Length], transform.position, Quaternion.identity);
            i++;
        }

    }*/
    IEnumerator roundLoop()
    {
        for (int i = 0; i < formation.Length; i++)
        {
            yield return new WaitForSeconds(formation[i].secondsSincePrevious);
            Instantiate(formation[i].enemy, transform.position, Quaternion.identity);            
        }
    }
}
