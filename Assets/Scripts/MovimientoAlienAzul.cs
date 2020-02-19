using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAlienAzul : MonoBehaviour
{
    public float velocidad = 4f; 
    public float radioVision;
    public float radioAtaque = 1.45f;
    //public GameObject per;
    Vector3 posicionInicial;
    Animator animator;
    Rigidbody2D rigidbody2;
    GameObject personaje;

    private int vidas = 3; 

    // Start is called before the first frame update
    void Start()
    {
        //recuperamos al jugador gracias al tag
        personaje = GameObject.FindGameObjectWithTag("Player");
        //personaje = per;

        //Guardamos nuestra posicion inicial
        posicionInicial = transform.position;

        animator = GetComponent<Animator>();
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //por defecto nuestro target siempre sera nuestra posicion inicial
        Vector3 target = posicionInicial;

        //comprobamos un raycast del enemigo hasta el jugador
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            personaje.transform.position - transform.position,
            radioVision,
            1 << LayerMask.NameToLayer("Default")
        );

        //aqui podemos debuguear el raycast
        Vector3 forward = transform.TransformDirection(personaje.transform.position - transform.position);
        Debug.DrawRay(transform.position, forward, Color.red);

        //Si el Raycast encuentra al jugador lo ponemos de target
        if(hit.collider != null){
            if(hit.collider.tag == "Player"){
                target = personaje.transform.position;
            }
        }

        //Calculamos la distancia y direccion actual hasta el target
        float distancia = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        bool atacando = stateInfo.IsName("Alien_ataque");

        //si es el enemigo y esta en rago de ataque nos paramos y le atacamos
        if(target != posicionInicial && distancia < radioAtaque && !atacando){
            //aqui le atacariamos
            animator.SetTrigger("Atacando");

        }
        else{
            //de lo contrario nos movemos hacia el
            rigidbody2.MovePosition(transform.position + dir * velocidad * Time.deltaTime);

            //Al movernos establecemos la animacion de movimiento
            animator.SetFloat("movX", dir.x);
            animator.SetFloat("movY", dir.y);
            animator.SetBool("Andando", true);
        }

        //una ultima comprobacion para evitar bugs forzando la posicion inicial
        if(target == posicionInicial && distancia < 0.02f){
            transform.position = posicionInicial;
            //Y cambiamos la animacion a parado
            animator.SetBool("Andando", false);
        }

        Debug.DrawLine(transform.position, target, Color.green);

        

    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioVision);
        Gizmos.DrawWireSphere(transform.position, radioAtaque);
    }

    public void golpeado()
    {
        vidas--;
        if (vidas == 0)
        {
            StartCoroutine(morir()); 
        }
    }

    IEnumerator morir()
    {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
        Destroy(this, 0.5f); 
    }

}
