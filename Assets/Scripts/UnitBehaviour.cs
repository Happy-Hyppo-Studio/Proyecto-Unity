using UnityEngine;
public class UnitBehaviour : MonoBehaviour
{
    public enum element
    {
        earth,
        water,
        air,
        fire
    }
    public element type;
    public Clock hitClock;
    private int health;
    public bool isAlly;
    private int currentHealth
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    public int maxHealth;
    public int damage;        
    public void DamageFormula(UnitBehaviour enemyStats)
    {
        if (enemyStats.type == type)
        {
            currentHealth -= enemyStats.damage;
        }
        else
        {
            currentHealth -= (int) (enemyStats.damage * 0.5f);
        }       
    }
    public void Awake()
    {
       currentHealth = maxHealth;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        UnitBehaviour unit = collision.gameObject.GetComponent<UnitBehaviour>();
        if (unit != null && unit.isAlly != isAlly)
        {
            StartCoroutine(hitClock.Cycle(() => DamageFormula(unit)));
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        UnitBehaviour unit = collision.gameObject.GetComponent<UnitBehaviour>();
        if (unit != null && unit.isAlly != isAlly)
        {
            StopCoroutine(hitClock.Cycle(() => DamageFormula(unit)));
        }
    }
}
