using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MonsterSpawnBehaviour : MonoBehaviour
{

    public static Action notifyMonsterSpawn;
    public static Action notifyWaterMonsterSpawn;
    public static Action notifyFireMonsterSpawn;
    public static Action notifyWindMonsterSpawn;
    public static Action notifyEarthMonsterSpawn;

    private CardManagerBehaviour cardManager;
    private ResourcesManagerBehaviour resourcesManager;

    public void Awake()
    {
        cardManager = GameObject.FindWithTag("Cards").GetComponent<CardManagerBehaviour>();
        resourcesManager=GameObject.FindWithTag("Resources").GetComponent<ResourcesManagerBehaviour>();
    }

    void OnMouseOver()
    {
        if (Time.timeScale != 0.0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
            
                if (resourcesManager.resources[(int)cardManager.selection.GetComponent<UnitBehaviour>().type] >= 5)
                {
                    resourcesManager.ResourceChange(-5, cardManager.selection.GetComponent<UnitBehaviour>().type);
                    Instantiate(cardManager.selection, transform.position - new Vector3(0.0f, 0.0f, 2.0f), transform.rotation);
                    EffectsControler.Instance.PlaySound(cardManager.soundSelection);

                    notifyMonsterSpawn?.Invoke();
                    if (cardManager.selection.GetComponent<UnitBehaviour>().type == element.water)
                    {
                        notifyWaterMonsterSpawn?.Invoke();
                    }
                    if (cardManager.selection.GetComponent<UnitBehaviour>().type == element.fire)
                    {
                        notifyFireMonsterSpawn?.Invoke();
                    }
                    if (cardManager.selection.GetComponent<UnitBehaviour>().type == element.air)
                    {
                        notifyWindMonsterSpawn?.Invoke();
                    }
                    if (cardManager.selection.GetComponent<UnitBehaviour>().type == element.earth)
                    {
                        notifyEarthMonsterSpawn?.Invoke();
                    }
                }
            }
        }
    }
}
