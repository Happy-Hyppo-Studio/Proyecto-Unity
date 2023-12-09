using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerBehaviour : MonoBehaviour
{
    public GameObject factory, spawner;
    void OnMouseOver()
    {
        if (Time.timeScale != 0.0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(spawner, factory.transform.position + new Vector3(0.0f, 1.0f, +0.0f)*0.6f/0.8f, transform.rotation);
                Destroy(factory);
                
            }
        }
    }
}
