using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public TimeRecorder pauseCatcher;

    public GameObject DBM;

    [SerializeField] private int currentLevel = 99;

    [SerializeField] private float levelPlayTime = 0.0f;

    [SerializeField] private int totalRecursosGenerados = 0;

    [SerializeField] private int totalRecursosFuego = 0;

    [SerializeField] private int totalRecursosAgua = 0;

    [SerializeField] private int totalRecursosAire = 0;

    [SerializeField] private int totalRecursosRoca = 0;

    [SerializeField] private int totalUnidadesCreadas = 0;

    [SerializeField] private int totalUnidadesFuego = 0;

    [SerializeField] private int totalUnidadesAgua = 0;

    [SerializeField] private int totalUnidadesAire = 0;

    [SerializeField] private int totalUnidadesRoca = 0;

    [SerializeField] private int resultadoPartida = 0;
    /*
    Tiempo: float
    Nº de recursos totales generados: int
    Nº de recursos específicos x4: int
    Nº de unidades totales creadas: int
    Nº de unidades específicas x4: int
    Ganar/perder: int (0 derrota, 1 victoria)
    */

    public void OnEnable() {
        MonsterSpawnBehaviour.notifyMonsterSpawn += IncreaseTotal;
        MonsterSpawnBehaviour.notifyWaterMonsterSpawn += IncreaseTotalAgua;
        MonsterSpawnBehaviour.notifyFireMonsterSpawn += IncreaseTotalFuego;
        MonsterSpawnBehaviour.notifyWindMonsterSpawn += IncreaseTotalAire;
        MonsterSpawnBehaviour.notifyEarthMonsterSpawn += IncreaseTotalRoca;


        ResourcesManagerBehaviour.notifyResourceSpawn += IncreaseRTotal;
        ResourcesManagerBehaviour.notifyResourceSpawnFire += IncreaseTotalRFuego;
        ResourcesManagerBehaviour.notifyResourceSpawnWater += IncreaseTotalRAgua;
        ResourcesManagerBehaviour.notifyResourceSpawnWind += IncreaseTotalRAire;
        ResourcesManagerBehaviour.notifyResourceSpawnRock += IncreaseTotalRRoca;

        WinConditionBehaviour.callVictory += getTimeAndVictory;
        LoseConditionBehaviour.callDefeat += getTimeAndDefeat;
    }

    public void OnDisable() {

        MonsterSpawnBehaviour.notifyMonsterSpawn -= IncreaseTotal;
        MonsterSpawnBehaviour.notifyWaterMonsterSpawn -= IncreaseTotalAgua;
        MonsterSpawnBehaviour.notifyFireMonsterSpawn -= IncreaseTotalFuego;
        MonsterSpawnBehaviour.notifyWindMonsterSpawn -= IncreaseTotalAire;
        MonsterSpawnBehaviour.notifyEarthMonsterSpawn -= IncreaseTotalRoca;

        ResourcesManagerBehaviour.notifyResourceSpawn -= IncreaseRTotal;
        ResourcesManagerBehaviour.notifyResourceSpawnFire -= IncreaseTotalRFuego;
        ResourcesManagerBehaviour.notifyResourceSpawnWater -= IncreaseTotalRAgua;
        ResourcesManagerBehaviour.notifyResourceSpawnWind -= IncreaseTotalRAire;
        ResourcesManagerBehaviour.notifyResourceSpawnRock -= IncreaseTotalRRoca;

        WinConditionBehaviour.callVictory -= getTimeAndVictory;
        LoseConditionBehaviour.callDefeat -= getTimeAndDefeat;

    }

    void IncreaseTotal() {
        totalUnidadesCreadas++;
    }

    void IncreaseTotalFuego() {
        totalUnidadesFuego++;
    }

    void IncreaseTotalAgua() {
        totalUnidadesAgua++;
    }

    void IncreaseTotalAire() {
        totalUnidadesAire++;
    }

    void IncreaseTotalRoca() {
        totalUnidadesRoca++;
    }

    //

    void IncreaseRTotal() {
        totalRecursosGenerados++;
    }

    void IncreaseTotalRFuego() {
        totalRecursosFuego++;
    }

    void IncreaseTotalRAgua() {
        totalRecursosAgua++;
    }

    void IncreaseTotalRAire() {
        totalRecursosAire++;
    }

    void IncreaseTotalRRoca() {
        totalRecursosRoca++;
    }

    void getTimeAndVictory()
    {
        levelPlayTime = pauseCatcher.timePlayed;
        resultadoPartida = 1;
        updateGameManager();
    }

    void getTimeAndDefeat()
    {
        levelPlayTime = pauseCatcher.timePlayed;
        resultadoPartida = 0;
        updateGameManager();
    }

    void updateGameManager()
    {

        globalDataManager.Instance.setnumeroNivel(currentLevel);

        globalDataManager.Instance.setTimePlayed(levelPlayTime);

        globalDataManager.Instance.setnumTotalRecursos(totalRecursosGenerados);

        globalDataManager.Instance.setnumTotalRecursoFuego(totalRecursosFuego);

        globalDataManager.Instance.setnumTotalRecursoAgua(totalRecursosAgua);

        globalDataManager.Instance.setnumTotalRecursoAire(totalRecursosAire);

        globalDataManager.Instance.setnumTotalRecursoRoca(totalRecursosRoca);

        globalDataManager.Instance.settotalUnidadesCreadas(totalUnidadesCreadas);

        globalDataManager.Instance.settotalUnidadesFuego(totalUnidadesFuego);

        globalDataManager.Instance.settotalUnidadesAgua(totalUnidadesAgua);

        globalDataManager.Instance.settotalUnidadesAire(totalUnidadesAire);

        globalDataManager.Instance.settotalUnidadesRoca(totalUnidadesRoca);

        globalDataManager.Instance.setresultadoPartida(resultadoPartida);

        DBM.SetActive(true);

    }



}
