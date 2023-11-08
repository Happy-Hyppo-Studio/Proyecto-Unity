using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourcesManagerBehaviour : MonoBehaviour
{
    //public int water, wind, earth, fire;
    public int[] resources;
    public EventHandler<int> waterHandler,windHandler,earthHandler,fireHandler,resourcesHandler;
    public void ResourceChange(int resource, element element)
    {
        switch (element)
        {
            case element.water:
                resources[0] += resource;
                waterHandler?.Invoke(this, resources[0]);
                break;
        
            case element.air:
                resources[1] += resource;
                windHandler?.Invoke(this, resources[1]);
                break;
        
            case element.earth:
                resources[2] += resource;
                earthHandler?.Invoke(this, resources[2]);
                break;
        
            case element.fire:
                resources[3] += resource;
                fireHandler?.Invoke(this, resources[3]);
                break;
        }
    }
}
