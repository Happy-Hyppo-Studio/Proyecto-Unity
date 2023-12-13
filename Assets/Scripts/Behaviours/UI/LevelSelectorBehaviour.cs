using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorBehaviour : MonoBehaviour
{
    public GameObject[] worlds;
    public Button right, left;
    private int world0=0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        right.onClick.AddListener(() => {
            if (world0 < worlds.Length - 1)
            {
                world0++;
                worlds[world0 - 1].SetActive(false);
                worlds[world0].SetActive(true);
            }
        });
        left.onClick.AddListener(() => {
            if (world0 > 0)
            {
                world0--;
                worlds[world0 + 1].SetActive(false);
                worlds[world0].SetActive(true);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
