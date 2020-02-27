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
        //Forzamos la resolución de la pantalla
        //Screen.SetResolution(800,800,true); 
        //Camera.main.projectionMatrix = Matrix4x4.Ortho(-5.0f * 1.6f , 5.0f * 1.6f, -5.0f, 0.5f, 0.3f, 1000f);
    }

    
    void Update()
    {
       /* if (!Screen.fullScreen || Camera.main.aspect != 1)
        {
            Screen.SetResolution(800,800,true); 
        }*/

        //Le dejamos al jugador salir de la pantalla completa
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit(); 
        }
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
