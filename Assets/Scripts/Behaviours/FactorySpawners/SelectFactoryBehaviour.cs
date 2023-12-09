using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFactoryBehaviour : MonoBehaviour
{
    public GameObject factory;
    public GameObject father;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseOver()
    {
        if (Time.timeScale != 0.0f) { 
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(factory, transform.parent.transform.position + new Vector3(0.0f, 0.439f, +0.0f)*0.75f, transform.rotation);
                father.SetActive(false);
            }
        }
    }
}
