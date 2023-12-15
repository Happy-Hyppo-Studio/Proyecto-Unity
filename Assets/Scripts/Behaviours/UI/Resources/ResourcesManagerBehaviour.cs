using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourcesManagerBehaviour : MonoBehaviour
{

    public static Action notifyResourceSpawn;
    public static Action notifyResourceSpawnFire;
    public static Action notifyResourceSpawnWater;
    public static Action notifyResourceSpawnWind;
    public static Action notifyResourceSpawnRock;
    //public int water, wind, earth, fire;

    //public int water, wind, earth, fire;
    public int[] resources;
    public EventHandler<int> waterHandler,windHandler,earthHandler,fireHandler,resourcesHandler;
    public void ResourceChange(int resource, element element)
    {

        notifyResourceSpawn?.Invoke();

        switch (element)
        {
            case element.water:
                resources[0] += resource;
                notifyResourceSpawnWater?.Invoke();
                waterHandler?.Invoke(this, resources[0]);
                break;
        
            case element.air:
                resources[2] += resource;
                notifyResourceSpawnWind?.Invoke();
                windHandler?.Invoke(this, resources[2]);
                break;
        
            case element.earth:
                resources[1] += resource;
                notifyResourceSpawnRock?.Invoke();
                earthHandler?.Invoke(this, resources[1]);
                break;
        
            case element.fire:
                resources[3] += resource;
                notifyResourceSpawnFire?.Invoke();
                fireHandler?.Invoke(this, resources[3]);
                break;
        }
    }
}
