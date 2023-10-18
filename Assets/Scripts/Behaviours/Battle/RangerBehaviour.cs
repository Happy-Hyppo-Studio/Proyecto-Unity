using UnityEngine;
public class RangerBehaviour : MonoBehaviour
{
    UnitBehaviour unit;
    Clock shootClock;
    GameObject bullet;
    public void Start()
    {
        unit = GetComponent<UnitBehaviour>();
        StartCoroutine(shootClock.Cycle(() =>
        {
            //codigo de generador
            Instantiate(bullet, this.transform);
        }));
    }
}