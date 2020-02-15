using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
   
    public Transform objetivo; 
    public float smoothing; 
    public Vector2 maxPosicion;
    public Vector2 minPosicion; 

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    
    //Se mueve despues del update del movimiento del personaje en cada frame
    void LateUpdate()
    {
        if (transform.position != objetivo.position)
        {
            Vector3 posicionObjetivo = new Vector3(objetivo.position.x, objetivo.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position,posicionObjetivo,smoothing);   

        }
    }
}
