using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MovimientoPersonaje : MonoBehaviour
{

    public float velocidad = 4f;
    Animator animator;
    Rigidbody2D rigidbody;
    Vector2 movimiento;
    CircleCollider2D colliderAtaque;

    public GameObject  uividas;
    public int llaves;

    public FloatValue saludJugador; 
    public Signal signalSalud; 
    public Inventario inventario; 
    public SpriteRenderer objetoRecibidoSprite;

    public bool cargado;

    //Prueba Inicio Mapa Nivel 2
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        colliderAtaque = transform.GetChild(0).GetComponent<CircleCollider2D>();
        //Lo desactivamos desde el principio
        colliderAtaque.enabled = false;
        //Gestionamos la carga de la partida
        DatosJugador datos = SistemaGuardado.cargarPartida();
        if (datos != null)
        {
            this.llaves = datos.llaves;
            this.transform.position = new Vector2(datos.posicion[0], datos.posicion[1]);
            cargado = true; 
           
        }
        else
        {
            this.llaves = 0;
            cargado = false;
        }
    }

    void Update()
    {

        if (!cargado)
        {
            saludJugador.valorEnEjecucion = 10;
            signalSalud.raise();
        }else
        {
            signalSalud.raise(); 
        }
    
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
        }
        else
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
            colliderAtaque.offset = new Vector2(movimiento.x / 2, movimiento.y / 2);
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
                //StartCoroutine(guardar());

            }
            else
            {
                colliderAtaque.enabled = false;
            }
        }
    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movimiento * velocidad * Time.deltaTime);
    }

    IEnumerator guardar()
    {
        yield return new WaitForSeconds(.3f);
        SistemaGuardado.guardarPartida(this, SceneManager.GetActiveScene().name);
    }


    public void getHit(float damage)
    {
        saludJugador.valorEnEjecucion -= damage;
        signalSalud.raise();
        if (saludJugador.valorEnEjecucion <= 0.0f)
        {
            StartCoroutine(morir()); 
        }
        Debug.Log("Vidas del personaje "+saludJugador.valorEnEjecucion);
    }

    IEnumerator morir() 
    {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
        Destroy(this, 0.5f); 
        SceneManager.LoadScene(4);
    }

    public void cojerObjeto()
    {
        animator.SetBool("recibiendoobjeto",true);
        objetoRecibidoSprite.sprite = inventario.objeto.spriteObjeto;
        if (inventario.objeto.llave)
        {
            this.llaves++;
            StartCoroutine(guardar());
        }
        StartCoroutine(pararRecibirObjeto());
    }

    IEnumerator pararRecibirObjeto()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("recibiendoobjeto",false);
        objetoRecibidoSprite.sprite = null;
    }
}