using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pararSeguimiento : MonoBehaviour
{
    GameObject mainC,ui,uiVida,enemigo;
    public GameObject barrera1,barrera2;
    // Start is called before the first frame update
    void Start()
    {
        mainC = GameObject.FindWithTag("MainCamera");
        ui = GameObject.FindWithTag("Ui");
        uiVida = GameObject.FindWithTag("Vidas");
        enemigo = GameObject.FindWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player"){
            mainC.GetComponent<AudioSource>().enabled = true;
            mainC.GetComponent<seguimientoPersonaje>().enabled = false;
            barrera1.GetComponent<BoxCollider2D>().enabled = true;
            barrera2.GetComponent<BoxCollider2D>().enabled = true;
            ui.GetComponent<seguimientoPersonaje>().enabled = false;
            uiVida.GetComponent<seguimientoPersonaje>().enabled = false;
            enemigo.GetComponent<Boss>().activate();
        }
    }
}
