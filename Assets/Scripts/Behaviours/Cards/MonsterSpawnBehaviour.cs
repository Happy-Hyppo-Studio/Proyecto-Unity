using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnBehaviour : MonoBehaviour
{
    public card[] orderedCards;
    public GameObject[] orderedPrefabs;
    private CardManagerBehaviour cardManager;
    private ResourcesManagerBehaviour resourcesManager;

    public void Awake()
    {
        cardManager = GameObject.FindWithTag("Cards").GetComponent<CardManagerBehaviour>();
        resourcesManager=GameObject.FindWithTag("Resources").GetComponent<ResourcesManagerBehaviour>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (resourcesManager.resources[(int)orderedPrefabs[cardManager.selection].GetComponent<UnitBehaviour>().type] > 5) 
            {
                resourcesManager.ResourceChange(-5, orderedPrefabs[cardManager.selection].GetComponent<UnitBehaviour>().type);
                Instantiate(orderedPrefabs[cardManager.selection], transform.position, transform.rotation);
            }
        }
    }
}
