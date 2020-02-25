using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
    MovimientoPersonaje personaje;
    // Start is called before the first frame update
    void Start()
    {
        personaje = GameObject.FindObjectOfType<MovimientoPersonaje>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void accion(int opcion){

        switch(opcion){
            case 1:
                print("arriba");
                break;
            case 2:
                print("abajo");
                break;
            case 3:
                print("der");
                break;
            case 4:
                print("izquierda");
                break;
            case 5:
                print("atacar");
                break;
        }

    }
}
