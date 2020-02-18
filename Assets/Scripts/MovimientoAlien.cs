using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAlien : MonoBehaviour
{
    public float velocidad = 4f; 
    Rigidbody2D rigidbody2;
    Vector2 mov;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        if (mov != Vector2.zero){
            animator.SetFloat("movX",mov.x);
            animator.SetFloat("movY", mov.y);
        }
        

    }

    void FixedUpdate() {
        rigidbody2.MovePosition(rigidbody2.position + mov * velocidad * Time.deltaTime);
    }
}
