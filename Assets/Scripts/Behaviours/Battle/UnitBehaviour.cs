﻿using System;
using System.Xml.Linq;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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
                //AnimationController.SetTrigger("DeathTrigger");
                if (animatorControler != null) { 
                    animatorControler.SetTrigger("DeathTrigger"); 
                }
                else {
                    Destroy(gameObject);
                }
            }
        }
    }

    [SerializeField] public AudioClip attackSound;

    public int currentHealth; //vida actual
    private Coroutine hitCoroutine;
    public Action deathAction;
    public int maxHealth; // vida maxima
    public bool isAlly; //informacion de bando de la unidad

   
    [SerializeField] private Animator animatorControler;
    [SerializeField] private bool weatherInmune;
    private bool fireWeakened;


    public void Start()
    {
        animatorControler = this.GetComponent<Animator>();//Recibimos el animator.

        currentHealth = maxHealth;//inicializar la vida al maximo


        int scene = SceneManager.GetActiveScene().buildIndex;

        if (scene >= 18)
        {
            fireWeakened = true;
        }

        if (fireWeakened && this.type == element.air && !weatherInmune)
        {
            StartCoroutine(DañoEntorno());
        }
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
                    health -= (int)(fighter.damage * 1.5f);//doble de da�o, ajustar si es necesario
                }
                else if (unit.type == (type - 1 == (element)(-1) ? element.fire : type - 1))  //elemento al que es fuerte
                {
                    //SI EL DAÑO ES MENOR A 2 SE HACE 0
                    health -= (int)(fighter.damage / 1.5f);//mitad de da�o, ajustar si es necesario
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

                //EffectsControler.Instance.PlaySound(attackSound);
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

    public IEnumerator DañoEntorno()
    {
        this.health -= 10;
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(DañoEntorno());
    }

    private void OnDestroy()
    {
        if (deathAction != null) deathAction();
    }
}