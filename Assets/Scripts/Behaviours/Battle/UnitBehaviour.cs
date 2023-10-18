using UnityEngine;
public class UnitBehaviour : MonoBehaviour
{
    public enum element //todos los elementos, ordenados 
    {
        water, //el agua es absorbida por la tierra 
        earth, //la tierra es arrastrada por el aire
        air,   //el aire sirve de alimento al fuego
        fire,   //el fuego es apagado por el agua
        aether  //elemento nulo
    }
    public element type;//el elemento de la unidad
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
    public int currentHealth; //vida actual
    public int maxHealth; // vida maxima
    public bool isAlly; //informacion de bando de la unidad
    public Clock hitClock;
    public void DamageFormula(int eDamage, element eElement)
    {
        //REHACER 
        //con operadores elvis para los extremos del enum elemental
        if (eElement == (type + 1 == (element)4 ? element.water : type + 1)) //elemento al que es debil
        {
            health -= eDamage * 2;//doble de da�o, ajustar si es necesario
        }
        else if (eElement == (type - 1 == (element)(-1) ? element.fire : type - 1))  //elemento al que es fuerte
        {
            health -= (int)( eDamage * 0.5f);//mitad de da�o, ajustar si es necesario
        }
        else //elemento igual o neutral
        {
            health -= eDamage;//neutral
        }
    }
    public void Start()
    {
        currentHealth = maxHealth;//inicializar la vida al maximo
    }
    private void OnCollisionEnter2D(Collision2D collision)//si EMPIEZA a colisionar
    {
        FighterBehaviour fighter = collision.gameObject.GetComponent<FighterBehaviour>();
        UnitBehaviour unit = collision.gameObject.GetComponent<UnitBehaviour>();
        if (fighter != null && unit.isAlly != isAlly)//si choca un enemigo
        {
            StartCoroutine(unit.hitClock.Cycle(() => DamageFormula(fighter.damage,unit.type)));//empieza corrutina de reloj que aplica el da�o como una expresion lambda
        }
    }
    private void OnCollisionExit2D(Collision2D collision)// si TERMINA de colisionar
    {
        FighterBehaviour fighter = collision.gameObject.GetComponent<FighterBehaviour>();
        UnitBehaviour unit = collision.gameObject.GetComponent<UnitBehaviour>();
        if (fighter != null && unit.isAlly != isAlly)
        {
            StopCoroutine(unit.hitClock.Cycle(() => DamageFormula(fighter.damage, unit.type)));//termina la corrutina de reloj empezada
        }
    }
}