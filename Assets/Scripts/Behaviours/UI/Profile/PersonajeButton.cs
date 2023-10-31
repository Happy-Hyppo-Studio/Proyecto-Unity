using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonajeButton : MonoBehaviour
{
    public Sprite spriteChico, spriteChica;
    private Button boton;
    public bool selected=true;// true=chico false=chica
    
    // Start is called before the first frame update
    void Start()
    {
        boton= GetComponent<Button>();
        boton.onClick.AddListener(()=>
            {
            selected = !selected;
            boton.image.sprite = (selected ? spriteChico : spriteChica);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
