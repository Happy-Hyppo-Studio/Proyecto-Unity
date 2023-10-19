using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourcesManagerBehaviour : MonoBehaviour
{
    public int water, wind, earth, fire;

    public EventHandler<int> waterHandler,windHandler,earthHandler,fireHandler;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ResourceChange(int resource, elements element)
    {
        switch (element)
        {
            case elements.water:
                water += resource;
                waterHandler?.Invoke(this, water);
                break;

            case elements.wind:
                wind += resource;
                windHandler?.Invoke(this, wind);
                break;

            case elements.earth:
                earth += resource;
                earthHandler?.Invoke(this, earth);
                break;

            case elements.fire:
                fire += resource;
                fireHandler?.Invoke(this, fire);
                break;
        }
    }
}
