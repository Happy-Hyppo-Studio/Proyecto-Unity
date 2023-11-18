using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanLineBehaviour : MonoBehaviour
{
    //SI TENEIS UNA IDEA QUE PENSAIS ES MAS RENTABLE PARA LA CREACION DE NIVELES NO DUDEIS EN EXPERIMENTARLA, ESTA ES LA QUE OS PUEDO DEJAR COMO TEMPLATE
    [System.Serializable]
    public struct formationUnit
    {
        public GameObject enemy;
        public float secondsSincePrevious;
    }   
    public formationUnit[] formation;
    private void Start()
    {
        StartCoroutine(roundLoop());
    }
    IEnumerator roundLoop()
    {
        Vector3 spawnPoint = (GetComponent<UnitBehaviour>().isAlly) ? this.transform.position + new Vector3(1, 0, 0) : this.transform.position + new Vector3(-1, 0, 0);
        while (true)
        {            
            for (int i = 0; i < formation.Length; i++)
            {
                yield return new WaitForSeconds(formation[i].secondsSincePrevious);
                Instantiate(formation[i].enemy, spawnPoint, Quaternion.identity);
            }
            yield return null;
        }       
    }
}
