using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colector : MonoBehaviour
{
    public int maxHp;
    public int hp;
    public int level;
    public int prodPerSec;
    public int levelPrice;
    public string type;

    private ColectorControler _colector;

    internal void Configure(ColectorControler colector, string material)
    {
        _colector = colector;

        var hp = 500;
        var maxHp = 500;
        var level = 1;
        var type = material;
        var prodPerSec = 10;
        var levelPrice = 1000;
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

    /*public void Demolish(Colector _colector)
    {
        Destroy(_colector);
    }*/
}
