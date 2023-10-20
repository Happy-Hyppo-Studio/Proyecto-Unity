using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourcesManagerBehaviour : MonoBehaviour
{
    public int water, wind, earth, fire;

    public EventHandler<int> waterHandler,windHandler,earthHandler,fireHandler;
    public void ResourceChange(int resource, element element)
    {
        switch (element)
        {
            case element.water:
                water += resource;
                waterHandler?.Invoke(this, water);
                break;

            case element.air:
                wind += resource;
                windHandler?.Invoke(this, wind);
                break;

            case element.earth:
                earth += resource;
                earthHandler?.Invoke(this, earth);
                break;

            case element.fire:
                fire += resource;
                fireHandler?.Invoke(this, fire);
                break;
        }
    }
}
