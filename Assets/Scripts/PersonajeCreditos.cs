using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeCreditos : MonoBehaviour
{

    public float speed;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(17.5f,transform.position.y, transform.position.z), step);
        animator.SetFloat("movX", 1);
        animator.SetFloat("movY", 0);
        animator.SetBool("andando", true);
    }
}
