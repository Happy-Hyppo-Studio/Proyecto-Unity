using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectNothingBehaviour : MonoBehaviour
{
    public GameObject spawner;
    public GameObject father;
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
        if (Input.GetMouseButtonDown(0))
        {
            spawner.SetActive(true);
            father.SetActive(false);
        }
    }
}
