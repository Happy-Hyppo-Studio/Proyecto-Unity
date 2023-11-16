using System.Xml.Linq;
using UnityEngine;
public class UnitBehaviour : MonoBehaviour
{    
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
    [SerializeField] private AudioClip attackSound;
    public int currentHealth; //vida actual
    private Coroutine hitCoroutine;
    public int maxHealth; // vida maxima
    public bool isAlly; //informacion de bando de la unidad
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
            hitCoroutine = StartCoroutine(fighter.hitClock.Cycle(() => 
            {

                EffectsControler.Instance.PlaySound(attackSound);
                //CODIGO DE DAÑO, PROVISIONAL/////
                //con operadores elvis para los extremos del enum elemental
                if (unit.type == (type + 1 == (element)4 ? element.water : type + 1)) //elemento al que es debil
                {
                    health -= fighter.damage * 2;//doble de da�o, ajustar si es necesario
                }
                else if (unit.type == (type - 1 == (element)(-1) ? element.fire : type - 1))  //elemento al que es fuerte
                {
                    //SI EL DAÑO ES MENOR A 2 SE HACE 0
                    health -= (int)(fighter.damage * 0.5f);//mitad de da�o, ajustar si es necesario
                }
                else //elemento igual o neutral
                {
                    health -= fighter.damage;//neutral
                }
            }));//empieza corrutina de reloj que aplica el da�o como una expresion lambda
        }
    }
    private void OnCollisionExit2D(Collision2D collision)// si TERMINA de colisionar
    {
        FighterBehaviour fighter = collision.gameObject.GetComponent<FighterBehaviour>();
        UnitBehaviour unit = collision.gameObject.GetComponent<UnitBehaviour>();
        if (fighter != null && unit.isAlly != isAlly)
        {
            StopCoroutine(hitCoroutine);//termina la corrutina de reloj empezada
        }
    } 
    private void OnTriggerEnter2D(Collider2D collision)//si entra en su trigger, esto solo sucede con los proyectiles
    {
        FighterBehaviour fighter = collision.gameObject.GetComponent<FighterBehaviour>();
        UnitBehaviour unit = collision.gameObject.GetComponent<UnitBehaviour>();
        if (fighter != null && unit.isAlly != isAlly)//si choca un enemigo
        {

                EffectsControler.Instance.PlaySound(attackSound);
                //CODIGO DE DAÑO, PROVISIONAL/////
                //con operadores elvis para los extremos del enum elemental
                if (unit.type == (type + 1 == (element)4 ? element.water : type + 1)) //elemento al que es debil
                {
                    health -= fighter.damage * 2;//doble de da�o, ajustar si es necesario
                }
                else if (unit.type == (type - 1 == (element)(-1) ? element.fire : type - 1))  //elemento al que es fuerte
                {
                    //SI EL DAÑO ES MENOR A 2 SE HACE 0
                    health -= (int)(fighter.damage * 0.5f);//mitad de da�o, ajustar si es necesario
                }
                else //elemento igual o neutral
                {
                    health -= fighter.damage;//neutral
                }
        }
    }
}