using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBehaviour : MonoBehaviour
{
    public Button closeButton;
    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(() => {
            Time.timeScale = 1.0f;
            this.gameObject.SetActive(false);
        });
    }

}
