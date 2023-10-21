using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactorySpawnBehaviour : MonoBehaviour
{
    public GameObject factorySelector;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            factorySelector.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
