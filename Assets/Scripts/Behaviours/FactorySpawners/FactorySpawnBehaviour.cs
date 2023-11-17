using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySpawnBehaviour : MonoBehaviour
{
    public GameObject factorySelector;
    
    void OnMouseOver()
    {
        if (Time.timeScale != 0.0f) { 
            if (Input.GetMouseButtonDown(0))
            {
                factorySelector.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
}
