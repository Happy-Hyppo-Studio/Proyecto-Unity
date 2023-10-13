using UnityEngine;
public class UnitBehaviour : MonoBehaviour
{
    public enum element
    {
        water,
        earth,
        air,
        fire
    }
    public element type;
    public Clock hitClock;
    public int health;
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
        if (enemyStats.type == (type + 1 == (element)4 ? element.water : type + 1)) //elemento al que es debil
        {            
            currentHealth -= enemyStats.damage * 2;
        }
        else if (enemyStats.type == (type - 1 == (element)(-1) ? element.fire : type - 1))  //elemento al que es fuerte
        { 
            currentHealth += (int) (enemyStats.damage * 0.5f);
        }
        else //elemento igual o "diagonal"
        {
            currentHealth -= enemyStats.damage;
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