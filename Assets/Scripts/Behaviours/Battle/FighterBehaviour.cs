using UnityEngine;
public class FighterBehaviour : MonoBehaviour
{

    float ypos;
    public int damage;
    public Vector2 speed;
    public Clock hitClock;
    private UnitBehaviour unit;
    private Rigidbody2D rb;

    //Animator Controller.
    [SerializeField] private Animator animatorControler;

    public void Awake()
    {
        ypos = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        unit = GetComponent<UnitBehaviour>();

        animatorControler = GetComponent<Animator>();//Recibimos el animator.        
        
        //AnimationController.SetTrigger("DeathTrigger");
        if (animatorControler != null) { animatorControler.SetTrigger("WalkTrigger"); }      
        

        
        rb.velocity = unit.isAlly ? speed : -speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)//si EMPIEZA a colisionar
    {
        UnitBehaviour enemyUnit =collision.gameObject.GetComponent<UnitBehaviour>();

        //if (animatorControler != null) { animatorControler.SetTrigger("IdleTrigger"); }

        if (enemyUnit != null && unit.isAlly != enemyUnit.isAlly)
        {

            //Animator Controller Attack trigger,
            if (animatorControler != null) { animatorControler.SetTrigger("AttackTrigger"); }
            

            rb.constraints = Constants.blockState;            
        }        


    }
    private void OnCollisionExit2D(Collision2D collision)// si TERMINA de colisionar
    {
        UnitBehaviour enemyUnit = collision.gameObject.GetComponent<UnitBehaviour>();
        rb.velocity = unit.isAlly ? speed : -speed;    //continua
        rb.constraints = Constants.walkState;

        if (animatorControler != null) { animatorControler.SetTrigger("WalkTrigger"); }        

        if (enemyUnit != null && unit.isAlly != enemyUnit.isAlly)
        {            
            transform.position = new Vector3(transform.position.x, ypos, transform.position.z);
        }       
    }

}