using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DatosJugador
{
    public float[] posicion;
    public int vidas;
    public int llaves; 
    public string escena; 

    public DatosJugador(MovimientoPersonaje personaje, string escena)
    {
        this.vidas = personaje.vidas;
        this.llaves = personaje.llaves;
        this.posicion = new float[3];
        this.posicion[0] = personaje.transform.position.x;
        this.posicion[1] = personaje.transform.position.y;
        this.posicion[2] = personaje.transform.position.z;
        this.escena = escena; 
    }
}
