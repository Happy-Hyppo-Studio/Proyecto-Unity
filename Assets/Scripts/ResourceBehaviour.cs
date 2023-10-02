using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceBehaviour : MonoBehaviour
{
    //Añadir todas los contadores que se ejecuten a una frecuencia distinta
    public Clock resourceClock;//bucle que genera el recurso
    public Clock updateResourceUIClock;//bucle de actualizacion de la UI
    

    // Start is called before the first frame update
    void Start()
    {
        //por ahora en Start para testeo, provisional
        StartCoroutine(resourceClock.Cycle(() =>
        {
            //////
            ///codigo de que hacer cuando el bucle de recursos termine un ciclo
            Debug.Log("uwu");


            //////
        }));
        StartCoroutine(updateResourceUIClock.Cycle(() =>
        {
            //////
            ///codigo de actualizacion de la UI
            Debug.Log("owo");


            //////
        }));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
