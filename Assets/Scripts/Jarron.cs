using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jarron : MonoBehaviour
{   
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void destruirJarron()
    {
        animator.SetBool("golpear",true); 
        StartCoroutine(romper());
    }

    IEnumerator romper()
    {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
        Destroy(this, 0.5f); 
    }
}
