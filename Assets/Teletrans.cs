using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Teletrans : MonoBehaviour
{
    public GameObject objetivo; 
    public bool necesitaTexto;
    public string nombreSitio; 
    public GameObject texto;
    public Text textolugar; 

 
    void Awake()
    {
        //Ocultamos los colisionadaores
        GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(0). GetComponent<SpriteRenderer>().enabled = false;
        
    }
    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag.Equals("Player"))
        {
            other.transform.position = objetivo.transform.GetChild(0).transform.position; 
            if (necesitaTexto)
            {
                StartCoroutine(gestionTexto()); 
            }
        }
    }


    private IEnumerator gestionTexto()
    {
        texto.SetActive(true); 
        textolugar.text = nombreSitio;
        yield return new WaitForSeconds(4f);
        texto.SetActive(false); 
    }
}
