using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseConditionBehaviour : MonoBehaviour
{
    public GameObject defeatMessage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        defeatMessage.SetActive(true);
    }
}
