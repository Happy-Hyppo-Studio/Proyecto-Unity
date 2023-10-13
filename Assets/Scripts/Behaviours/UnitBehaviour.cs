using UnityEngine;
public class UnitBehaviour : MonoBehaviour
{
    public enum element //todos los elementos, ordenados 
    {
        water, //el agua es absorbida por la tierra 
        earth, //la tierra es arrastrada por el aire
        air,   //el aire sirve de alimento al fuego
        fire   //el fuego es apagado por el agua
    }
    public element type;//el elemento de la unidad
    public Clock hitClock;//reloj del cooldown de golpes
    private int health //getter y setter modificados de la vida actual
    {
        get { return currentHealth; } //original del getter
        set
        {
            currentHealth = value; //original del setter
            if (currentHealth <= 0) //si la vida llega o supera el 0
            {
                //destruccion automatica del objeto, si se quiere animacion de muerte cambiar esto
                Destroy(gameObject);
            }
        }
    }
    private int currentHealth; //vida actual
    public int maxHealth; // vida maxima
    public int damage; //daño por golpe
    public bool isAlly; //informacion de bando de la unidad
    public void DamageFormula(UnitBehaviour enemyStats)
    {
        //con operadores elvis para los extremos del enum elemental
        if (enemyStats.type == (type + 1 == (element) 4 ? element.water : type + 1)) //elemento al que es debil
        {            
            health -= enemyStats.damage * 2;//doble de daño, ajustar si es necesario
        }
        else if (enemyStats.type == (type - 1 == (element)(-1) ? element.fire : type - 1))  //elemento al que es fuerte
        { 
            health += (int) (enemyStats.damage * 0.5f);//mitad de daño, ajustar si es necesario
        }
        else //elemento igual o neutral
        {
            health -= enemyStats.damage;//neutral
        }  
    }
    public void Start()
    {
        currentHealth = maxHealth;//inicializar la vida al maximo
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
    private void OnCollisionEnter2D(Collision2D collision)//si EMPIEZA a colisionar
    {
        UnitBehaviour unit = collision.gameObject.GetComponent<UnitBehaviour>();
        if (unit != null && unit.isAlly != isAlly)//si choca un enemigo
        {
            StartCoroutine(hitClock.Cycle(() => DamageFormula(unit)));//empieza corrutina de reloj que aplica el daño como una expresion lambda
        }
    }
    private void OnCollisionExit2D(Collision2D collision)// si TERMINA de colisionar
    {
        UnitBehaviour unit = collision.gameObject.GetComponent<UnitBehaviour>();
        if (unit != null && unit.isAlly != isAlly)
        {
            StopCoroutine(hitClock.Cycle(() => DamageFormula(unit)));//termina la corrutina de reloj empezada
        }
    }

}