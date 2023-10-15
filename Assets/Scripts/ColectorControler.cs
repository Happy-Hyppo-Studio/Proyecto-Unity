using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectorControler : MonoBehaviour
{
    [SerializeField] public int constPrice;

    public ObjectPooling _pool;

    public int fireProd;
    public int airProd;
    public int waterProd;
    public int rockProd;

    public int fire;
    public int air;
    public int water;
    public int rock;


    public ColectorControler(ObjectPooling pool)
    {
        _pool = pool;

        fire = 0;
        air = 0;
        water = 0;
        rock = 0;
    }

    void Start()
    {
        _pool.Init();

        Debug.Log("hola mundo");
    }

    private void fixedUpdate()
    {
        Colecting();

        Debug.Log("fire: " + fire);
        Debug.Log("water: " + water);
        Debug.Log("air: " + air);
        Debug.Log("rock: " + rock);
    }

    public void UpgradeColector(Colector colector)
    {
        colector.LevelUp();
        RecountRate();
    }

    public void RecountRate()
    {
        fireProd = 0;
        airProd = 0;
        waterProd = 0;
        rockProd = 0;

        /*for (var i = 0; i < _colectorList.Count; i++)
        {
            var instance = _colectorList.Dequeue();

            if (instance.type == "fire")
            {
                fireProd += instance.prodPerSec;
            } 
            else if(instance.type == "water")
            {
                waterProd += instance.prodPerSec;
            } 
            else if(instance.type == "air")
            {
                airProd += instance.prodPerSec;
            } 
            else if(instance.type == "rock")
            {
                rockProd += instance.prodPerSec;
            }

            _colectorList.Enqueue(instance);
        }*/
    }


    //A continuación va toda la parte de "Object pool" 
    //De momento lo dejo todo en el mismo documento pero estoy pensando en como dividirlo, ya veré
    //El pool lo que hace es guardar un máximo de 40 recolectors (asumiendo que el máximo son 10) en el caso peor de que el jugador cree 10 de cada y los pierda
    //Una vez le destruyen un recolector en vez de destruirse se guarda en la cola de su tipo y la proxima vez que cree uno comprobará si hay en cola para rciclar o no, y dependiendo de eso crea un nuevo recolector o lo activa

    //Probablemente lo mejor sea hacer un script a parte de pool para que se pueda reutilizar para otras cosas como los enemigos o aliados


    public IEnumerator Colecting()
    {
        yield return new WaitForSeconds(3);

        fire += fireProd;
        air += airProd;
        water += waterProd;
        rock += rockProd;
    }
}
