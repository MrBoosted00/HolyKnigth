using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fondo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject personaje;
    public float parallaxSpeed = 0.02f;
    public RawImage background_luna;
    public RawImage background_monta;
    public RawImage background_cemen;
    private float posicion;

    void Start()
    {
       
        posicion = transform.position.x - personaje.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (background_monta != null)
        {
            if (personaje.GetComponent<Personaje>().gethInput() > 0)
            {
                float finalSpeed = parallaxSpeed * Time.deltaTime;
                // background_luna.uvRect= new Rect (background_luna.uvRect.x + finalSpeed,0f,1f,1f);
                background_monta.uvRect = new Rect(background_monta.uvRect.x + finalSpeed, 0f, 1f, 1f);
                background_cemen.uvRect = new Rect(background_cemen.uvRect.x + finalSpeed * 2, 0f, 1f, 1f);
            }

            if (personaje.GetComponent<Personaje>().gethInput() < 0)
            {
                float finalSpeed = parallaxSpeed * Time.deltaTime;
                //  background_luna.uvRect= new Rect (background_luna.uvRect.x - finalSpeed,0f,1f,1f);
                background_monta.uvRect = new Rect(background_monta.uvRect.x - finalSpeed, 0f, 1f, 1f);
                background_cemen.uvRect = new Rect(background_cemen.uvRect.x - finalSpeed * 2, 0f, 1f, 1f);
            }
            transform.position = new Vector3(personaje.transform.position.x + posicion, transform.position.y, transform.position.z);
        }
        else
        {
            if (personaje.GetComponent<Personaje>().gethInput() > 0)
            {
                float finalSpeed = parallaxSpeed * Time.deltaTime;
                // background_luna.uvRect= new Rect (background_luna.uvRect.x + finalSpeed,0f,1f,1f);

                background_cemen.uvRect = new Rect(background_cemen.uvRect.x + finalSpeed * 2, 0f, 1f, 1f);
            }

            if (personaje.GetComponent<Personaje>().gethInput() < 0)
            {
                float finalSpeed = parallaxSpeed * Time.deltaTime;
                //  background_luna.uvRect= new Rect (background_luna.uvRect.x - finalSpeed,0f,1f,1f);

                background_cemen.uvRect = new Rect(background_cemen.uvRect.x - finalSpeed * 2, 0f, 1f, 1f);
            }
            transform.position = new Vector3(personaje.transform.position.x + posicion, transform.position.y, transform.position.z);




        }

    }
}
