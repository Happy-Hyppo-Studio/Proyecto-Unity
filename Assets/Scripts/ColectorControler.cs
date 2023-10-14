using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectorControler : MonoBehaviour
{
    private Colector _colector;

    [SerializeField] public int constPrice;
    [SerializeField] public int maxColectors;
    private Queue<Colector> _colectorList;

    //[SerializeField] public int dinero; //provisional para probar si funciona

    public int fireProd;
    public int airProd;
    public int waterProd;
    public int rockProd;

    public int fire;
    public int air;
    public int water;
    public int rock;

    public ColectorControler(Colector colector)
    {
        var fire = 0;
        var air = 0;
        var water = 0;
        var rock = 0;

        var _colector = colector;
        var _colectorList = new Queue<Colector>(maxColectors);
    }

    void Awake()
    {
        AddColector("fire");
        AddColector("fire");
        AddColector("air");
        AddColector("air");
        AddColector("rock");
        AddColector("water");

        Debug.Log("hola");
    }

    private void fixedUpdate()
    {
        Colecting();

        Debug.Log("fire: " + fire);
        Debug.Log("water: " + water);
        Debug.Log("air: " + air);
        Debug.Log("rock: " + rock);
    }

    public void AddColector(string type)
    {
        //if (dinero >= constPrice)
        //{
            //var instance = InstantiateColector();
            //instance.gameObject.SetActive(true);
            var instance = InstantiateColector(type);
            instance.gameObject.SetActive(true);
            _colectorList.Enqueue(instance);

            RecountRate();
        /*} else
        {
            Debug.Log("Tu ele poble tu no tiene aifon");
        }*/
    }

    private Colector InstantiateColector(string type)
    {
        var instance = Object.Instantiate(_colector);
        instance.Configure(this, type);
        return instance;
    }

    public void UpgradeColector(Colector colector)
    {
        /*if (dinero >= colector.levelPrice)
        {*/
            colector.LevelUp();

            RecountRate();
        /*}
        else
        {
            Debug.Log("Tu ele poble tu no tiene aifon");
        }*/
    }

    public void RecountRate()
    {
        fireProd = 0;
        airProd = 0;
        waterProd = 0;
        rockProd = 0;

        for (var i = 0; i < _colectorList.Count; i++)
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
        }
    }

    public IEnumerator Colecting()
    {
        yield return new WaitForSeconds(3);

        fire += fireProd;
        air += airProd;
        water += waterProd;
        rock += rockProd;
    }
}
