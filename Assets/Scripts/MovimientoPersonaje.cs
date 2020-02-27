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
    public AudioSource sonido;
    public int llaves;
    public int vidas;
    public Inventario inventario;
    public SpriteRenderer objetoRecibidoSprite;
    public GameObject herramientaCofres;

    //Gestión joystick
    public Joystick joystick;
    public JoyButton joyButton;


    //Prueba Inicio Mapa Nivel 2
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        colliderAtaque = transform.GetChild(0).GetComponent<CircleCollider2D>();
        //Lo desactivamos desde el principio
        colliderAtaque.enabled = false;
        gestionCargaPartida();
    }

    void Update()
    {
        //Joystick (para ejecución en Android)
        if (Application.platform == RuntimePlatform.Android)
        {
            movimiento = new Vector2(joystick.Horizontal, joystick.Vertical);
        }
        else //Teclas normales AWDS, y flechas (para ejecución en PC)
        {
            movimiento = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"));
        }  
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
        if ((Input.GetKeyDown(KeyCode.Space) || joyButton.pulsado )&& !atacando)
        {
            atacar();
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
            }
            else
            {
                colliderAtaque.enabled = false;
            }
        }
    }

    //Gestionamos las físicas del personaje en el fixed Update
    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movimiento * velocidad * Time.deltaTime);
    }

    //Este método se encarga de gestionar la carga de la partida
    private void gestionCargaPartida()
    {
        //Gestionamos la carga de la partida
        DatosJugador datos = SistemaGuardado.cargarPartida();
        if (datos != null)
        {
            this.llaves = datos.llaves;
            this.vidas = datos.vidas;
            this.transform.position = new Vector2(datos.posicion[0], datos.posicion[1]);
        }
        else
        {
            this.llaves = 0;
            this.vidas = 5;
        }
    }

    public void atacar()
    {
        animator.SetTrigger("atacando");
        Instantiate(sonido);
    }
  
    public void getHit(int damage)
    {
        vidas -= damage;
        if (vidas <= 0)
        {
            StartCoroutine(morir());
        }
        Debug.Log("Vidas del personaje " + vidas);
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
        animator.SetBool("recibiendoobjeto", true);
        objetoRecibidoSprite.sprite = inventario.objeto.spriteObjeto;
        if (inventario.objeto.llave)
        {
            this.llaves++;
        }
        StartCoroutine(pararRecibirObjeto());
    }

    IEnumerator pararRecibirObjeto()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("recibiendoobjeto", false);
        objetoRecibidoSprite.sprite = null;
        StartCoroutine(actualizarCofres());
    }

    IEnumerator actualizarCofres()
    {
        yield return new WaitForSeconds(.3f);
        herramientaCofres.GetComponent<GestionCofresAbiertos>().guardar();
        herramientaCofres.GetComponent<GestionCofresAbiertos>().actualizarEstado();
        gestionarDescompensacionLlaves();
    }

    //Este método es debido a que cuando utilizamos la interfaz táctil, cuando recibimos una llave de
    //un cofre, parece que registra más pulsaciones de lo normal y recoge más de una llave. Con el espacio
    //todo funciona correctamente
    private void gestionarDescompensacionLlaves()
    {
        //Las llaves serán igual al número de cofres abiertos
        int contadorAbiertos = 0;
        for (int i = 0; i < herramientaCofres.GetComponent<GestionCofresAbiertos>().listaCofresenMapa.Length; i++)
        {
            //Si no está activo es que está abierto
            if (!herramientaCofres.GetComponent<GestionCofresAbiertos>().listaCofresenMapa[i].activeSelf)
            {
                contadorAbiertos++;
            }
        }
        this.llaves = contadorAbiertos;
        StartCoroutine(guardar());
    }

    //Guardamos la partida cuando abrimos un cofre y arreglamos las llaves si estamos jugando en móvil
    IEnumerator guardar()
    {
        yield return new WaitForSeconds(.3f);
        SistemaGuardado.guardarPartida(this, SceneManager.GetActiveScene().name);
    }
}