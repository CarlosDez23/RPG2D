using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{   

    public float velocidad = 4f; 
    Animator animator;
    Rigidbody2D rigidbody; 
    Vector2 movimiento;
    CircleCollider2D colliderAtaque; 

    public int vidas; 
    public int llaves; 
    
    //Prueba Inicio Mapa Nivel 2
    void Start()
    {
        animator = GetComponent<Animator>(); 
        rigidbody = GetComponent<Rigidbody2D>(); 
        colliderAtaque = transform.GetChild(0).GetComponent<CircleCollider2D>(); 
        //Lo desactivamos desde el principio
        colliderAtaque.enabled = false; 
        this.vidas  = 5; 
        this.llaves = 0; 
    }

    void Update()
    {
        movimiento = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")    
        ); 

        //Solo actualizamos la animación cuando nos estemos moviendo
        if (movimiento != Vector2.zero)
        {
            animator.SetFloat("movX", movimiento.x);
            animator.SetFloat("movY", movimiento.y);  
            animator.SetBool("andando", true); 
        } else
        {
            animator.SetBool("andando", false); 
        }

        //Miramos el estado actual en el animador
        AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
        bool atacando = info.IsName("Jugador_atacando");
        //No dejamos atacar hasta que no termine la animación 
        if (Input.GetKeyDown(KeyCode.Space) && !atacando)
        {
            animator.SetTrigger("atacando"); 
        }

        //Actualizamos la posición del collider de ataque en función de donde está mirando el personaje 
        if (movimiento != Vector2.zero)
        {
            colliderAtaque.offset = new Vector2(movimiento.x/2, movimiento.y/2);
        }

        if (atacando)
        {
            //Normalizedtime guarda el tiempo que dura la animación
            float tiempoAnimacion = info.normalizedTime; 
            //Si lo dividimos en 3 tercios, y activamos el collider del ataque en el segundo tercio
            //conseguimos que el collider solo este activo en mitad de la animación
            if (tiempoAnimacion > 0.33 && tiempoAnimacion < 0.66)
            {
                colliderAtaque.enabled = true; 
            }else
            {
                colliderAtaque.enabled = false; 
            }
        }
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movimiento * velocidad * Time.deltaTime);
    }
}