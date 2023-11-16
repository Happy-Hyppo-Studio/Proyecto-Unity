using UnityEngine;
public class RangerBehaviour : MonoBehaviour
{
    UnitBehaviour unit;
    public Clock shootClock;
    public GameObject bullet;
    public void Start()
    {
        unit = GetComponent<UnitBehaviour>();
        Vector3 spawnPoint =(unit.isAlly) ? this.transform.position + new Vector3(1, 0, 0) : this.transform.position + new Vector3(-1,0,0);
        StartCoroutine(shootClock.Cycle(() =>
        {
            //codigo de generador
            Instantiate(bullet, spawnPoint, Quaternion.identity);
        }));
    }
}