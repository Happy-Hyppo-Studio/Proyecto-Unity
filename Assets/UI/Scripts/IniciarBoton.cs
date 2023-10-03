using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IniciarBoton : MonoBehaviour
{
    public TMP_InputField nombreInput;
    public Slider edadInput;
    public Button botonPersonaje;
    private Button boton;
    private string nombre;
    private int edad;
    private bool personaje;
    private string personajeString;

    // Start is called before the first frame update
    void Start()
    {
        boton=GetComponent<Button>();
        boton.onClick.AddListener(() =>
        {
            nombre=nombreInput.text;
            edad = (int)edadInput.value;
            personaje = botonPersonaje.GetComponent<PersonajeButton>().selected;
            personajeString = (personaje) ? "Chico" : "Chica";
            Debug.Log(nombre+" " + personajeString + " " + edad);
            if (nombre == "")
            {

            }
            else
            {
                string path = "Assets/inicioSesión.txt";
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine(nombre + " " + personajeString + " " + edad);
                sw.Close();
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
