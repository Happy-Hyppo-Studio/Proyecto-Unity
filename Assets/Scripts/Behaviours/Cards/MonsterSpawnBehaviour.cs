using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnBehaviour : MonoBehaviour
{
    public card[] orderedCards;
    public GameObject[] orderedPrefabs;
    private CardManagerBehaviour cardManager;

    public void Awake()
    {
        cardManager = GameObject.FindWithTag("Cards").GetComponent<CardManagerBehaviour>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Instantiate(orderedPrefabs[cardManager.selection], transform.position, transform.rotation);
        }
    }
}
