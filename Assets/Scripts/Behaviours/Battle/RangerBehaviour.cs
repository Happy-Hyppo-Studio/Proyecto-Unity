using UnityEngine;
public class RangerBehaviour : MonoBehaviour
{
    UnitBehaviour unit;
    public Clock shootClock;
    public GameObject bullet;
    public void Start()
    {
        Vector3 spawnPoint = this.transform.position + new Vector3(-1,0,0);
        unit = GetComponent<UnitBehaviour>();
        StartCoroutine(shootClock.Cycle(() =>
        {
            //codigo de generador
            Instantiate(bullet, spawnPoint, Quaternion.identity);
        }));
    }
}