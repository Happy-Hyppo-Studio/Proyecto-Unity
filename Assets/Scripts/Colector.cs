using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colector : RecyclableObject
{
    public int maxHp;
    public int hp;
    public int level;
    public int prodPerSec;
    public int levelPrice;
    public string type;

    public ColectorControler _controler;

    internal override void Init()
    {
        hp = 500;
        maxHp = 500;
        level = 1;
        prodPerSec = 10;
        levelPrice = 1000;
    }

    void Start()
    {
        Debug.Log("hola mundo");
    }

    public Colector (string material, ColectorControler controler)
    {
        type = material;
        _controler = controler;
    }

    public void LevelUp()
    {
        maxHp += 100 * level;
        hp += 100 * level;
        prodPerSec = prodPerSec + 100 * level;
        levelPrice = levelPrice + 500;
    }

    public IEnumerator Repair()
    {
        //Añadir var para que no produzca mientras se repara

        var missingHealth = maxHp - hp;
        while (hp != maxHp)
        {
            if ((maxHp - hp) >= 10)
            {
                hp += 10;
                yield return new WaitForSeconds(3);
            }
            else
            {
                hp = maxHp;
                yield return new WaitForSeconds(3);
            }
        }
    }

    internal override void Release()
    {
        _controler.RecountRate();
    }
}
