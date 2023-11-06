using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanLineBehaviour : MonoBehaviour
{
    //SI TENEIS UNA IDEA QUE PENSAIS ES MAS RENTABLE PARA LA CREACION DE NIVELES NO DUDEIS EN EXPERIMENTARLA, ESTA ES LA QUE OS PUEDO DEJAR COMO TEMPLATE
    public int[] timeOffsets = {/*meter aqui los tiempos de en que momento se genera un nuevo enemigo en la linea segun el plan, en segundos, de menor a mayor*/};
    int i = 0;
    // Update is called once per frame
    void Update()//mucha pereza ahora para hacer corrutinas, optimizare mas tarde
    {
        if (Time.timeSinceLevelLoad > timeOffsets[i])
        {
            Instantiate(this.gameObject/*enemigo, this es placecolder*/, Vector3.zero, Quaternion.identity /*unir este script a un gameobject vacio delante de las torres enemigas*/);
            i++;
        }

    }
}
