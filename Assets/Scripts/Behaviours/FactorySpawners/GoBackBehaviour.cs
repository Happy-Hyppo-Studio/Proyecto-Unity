using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackBehaviour : MonoBehaviour
{
    public GameObject father;
    void OnMouseOver()
    {
        if (Time.timeScale != 0.0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                father.SetActive(false);
            }
        }
    }
}
