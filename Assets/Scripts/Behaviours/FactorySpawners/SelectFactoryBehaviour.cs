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
        
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(factory, transform.parent.transform.position, transform.rotation);
            father.SetActive(false);
        }
    }
}
