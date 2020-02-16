using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{   

    public float velocidad = 4f; 

    Animator animator;
    Rigidbody2D rigidbody; 
    Vector2 movimiento;
    
    //Prueba de carlos
    //Prueba de Adrian
    void Start()
    {
        animator = GetComponent<Animator>(); 
        rigidbody = GetComponent<Rigidbody2D>(); 
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("atacando"); 
        }
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movimiento * velocidad * Time.deltaTime);
    }
}
