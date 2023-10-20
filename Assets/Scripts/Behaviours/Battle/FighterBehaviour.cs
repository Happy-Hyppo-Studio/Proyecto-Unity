using UnityEngine;
public class FighterBehaviour : MonoBehaviour
{
    public int damage;
    public Vector2 speed;
    public Clock hitClock;
    private UnitBehaviour unit;
    private Rigidbody2D rb;
    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        unit = GetComponent<UnitBehaviour>();       
        rb.velocity = unit.isAlly ? speed : -speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)//si EMPIEZA a colisionar
    {
        UnitBehaviour enemyUnit =collision.gameObject.GetComponent<UnitBehaviour>();
        if (enemyUnit != null && unit.isAlly != enemyUnit.isAlly)
        {
            rb.velocity = Vector2.zero;//para
        }       
    }
    private void OnCollisionExit2D(Collision2D collision)// si TERMINA de colisionar
    {
        UnitBehaviour enemyUnit = collision.gameObject.GetComponent<UnitBehaviour>();
        if (enemyUnit != null && unit.isAlly != enemyUnit.isAlly)
        {
            rb.velocity = unit.isAlly ? speed : -speed;    //continua   
        }       
    }
}