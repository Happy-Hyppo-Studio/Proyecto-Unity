using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryDestroyer : MonoBehaviour
{
    public GameObject destroyer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseOver()
    {
        if (Time.timeScale != 0.0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                destroyer.SetActive(true);
            }
        }
    }
}
