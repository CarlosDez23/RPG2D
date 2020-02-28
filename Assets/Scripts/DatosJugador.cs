using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DatosJugador
{
    public float[] posicion;
    public int llaves; 
    public int vidas;
    public string escena; 

    public DatosJugador(MovimientoPersonaje personaje, string escena)
    {
        this.llaves = personaje.llaves;
        this.vidas = personaje.vidas;
        this.posicion = new float[3];
        this.posicion[0] = personaje.transform.position.x;
        this.posicion[1] = personaje.transform.position.y;
        this.posicion[2] = personaje.transform.position.z;
        this.escena = escena; 
    }
    public DatosJugador(int llaves, int vidas, float[] posicion, string escena)
    {
        this.llaves = llaves;
        this.vidas = vidas;
        this.posicion = new float[3];
        this.posicion[0] = posicion[0];
        this.posicion[1] = posicion[1];
        this.posicion[2] = posicion[2];
        this.escena = escena; 
    }
}
