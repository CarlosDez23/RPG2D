using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorazonesManager : MonoBehaviour
{

    public Image[] corazones; 
    public Sprite corazonLleno;
    public Sprite corazonMitad;
    public Sprite corazonVacio;
    public FloatValue contenedor;
    // Start is called before the first frame update
    void Start()
    {
        iniciarCorazones();
    }

    public void iniciarCorazones()
    {
        for (int i = 0; i < contenedor.valorInicial; i++)
        {
            corazones[i].gameObject.SetActive(true);
            corazones[i].sprite = corazonLleno; 
        }
    }
}
