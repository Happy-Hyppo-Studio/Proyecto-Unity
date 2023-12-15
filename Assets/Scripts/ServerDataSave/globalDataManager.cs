using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalDataManager : MonoBehaviour
{

    public static globalDataManager Instance;

    /*

    Nombre: varchar
    Edad: int
    Género: int (0 masculino, 1 femenino)
    Número de nivel: int
    Tiempo: float
    Nº de recursos totales generados: int
    Nº de recursos específicos x4: int
    Nº de unidades totales creadas: int
    Nº de unidades específicas x4: int
    Ganar/perder: int (0 derrota, 1 victoria)


    */

    [SerializeField] private string Nombre;
    
    [SerializeField] private int Edad;

    [SerializeField] private int Genero;
    
    [SerializeField] private int numeroNivel;

    [SerializeField] private float timePlayed;

    [SerializeField] private int numTotalRecursos= 0;

    [SerializeField] private int numTotalRecursoAgua= 0;

    [SerializeField] private int numTotalRecursoFuego= 0;

    [SerializeField] private int numTotalRecursoAire= 0;

    [SerializeField] private int numTotalRecursoRoca= 0;

    [SerializeField] private int totalUnidadesCreadas = 0;

    [SerializeField] private int totalUnidadesFuego = 0;

    [SerializeField] private int totalUnidadesAgua = 0;

    [SerializeField] private int totalUnidadesAire = 0;

    [SerializeField] private int totalUnidadesRoca = 0;

    [SerializeField] private int resultadoPartida = 0;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void setEdad(int nuevaEdad){
        Edad = nuevaEdad;
    }

    public void setNombre(string nuevoNombre){
        Nombre = nuevoNombre;
    }

    public void setGenero(int nuevoGenero){
        Genero = nuevoGenero;
    }

    public void setnumeroNivel(int nuevoGenero)
    {
        numeroNivel = nuevoGenero;
    }

    public void setTimePlayed(float nuevoGenero)
    {
        timePlayed = nuevoGenero;
    }

    public void setnumTotalRecursos(int nuevoGenero)
    {
        numTotalRecursos = nuevoGenero;
    }

    public void setnumTotalRecursoAgua(int nuevoGenero)
    {
        numTotalRecursoAgua = nuevoGenero;
    }
    public void setnumTotalRecursoFuego(int nuevoGenero)
    {
        numTotalRecursoFuego = nuevoGenero;
    }
    public void setnumTotalRecursoAire(int nuevoGenero)
    {
        numTotalRecursoAire = nuevoGenero;
    }
    public void setnumTotalRecursoRoca(int nuevoGenero)
    {
        numTotalRecursoRoca = nuevoGenero;
    }
    public void settotalUnidadesCreadas(int nuevoGenero)
    {
        totalUnidadesCreadas = nuevoGenero;
    }
    public void settotalUnidadesFuego(int nuevoGenero)
    {
        totalUnidadesFuego = nuevoGenero;
    }
    public void settotalUnidadesAgua(int nuevoGenero)
    {
        totalUnidadesAgua = nuevoGenero;
    }
    public void settotalUnidadesAire(int nuevoGenero)
    {
        totalUnidadesAire = nuevoGenero;
    }
    
    public void settotalUnidadesRoca(int nuevoGenero)
    {
        totalUnidadesRoca = nuevoGenero;
    }
    
    public void setresultadoPartida(int nuevoGenero)
    {
        resultadoPartida = nuevoGenero;
    }

    //Getters


    public int getEdad()
    {
        return Edad;
    }

    public string getNombre()
    {
        return Nombre;
    }

    public int getGenero()
    {
        return Genero;
    }

    public int getnumeroNivel()
    {
        
        return numeroNivel;
    }

    public int getTimePlayed()
    {
        int tiempoJugado = (int)(Mathf.Round(timePlayed));
        return tiempoJugado;
    }

    public int getnumTotalRecursos()
    {
        return numTotalRecursos;
    }

    public int getnumTotalRecursoAgua()
    {
        return numTotalRecursoAgua;
    }
    public int getnumTotalRecursoFuego()
    {
        return numTotalRecursoFuego;
    }
    public int getnumTotalRecursoAire()
    {
        return numTotalRecursoAire;
    }
    public int getnumTotalRecursoRoca()
    {
        return numTotalRecursoRoca;
    }
    public int gettotalUnidadesCreadas()
    {
        return totalUnidadesCreadas;
    }
    public int gettotalUnidadesFuego()
    {
        return totalUnidadesFuego;
    }
    public int gettotalUnidadesAgua()
    {
        return totalUnidadesAgua;
    }
    public int gettotalUnidadesAire()
    {
        return totalUnidadesAire;
    }

    public int gettotalUnidadesRoca()
    {
        return totalUnidadesRoca;
    }

    public int getresultadoPartida()
    {
        return resultadoPartida;
    }


}
