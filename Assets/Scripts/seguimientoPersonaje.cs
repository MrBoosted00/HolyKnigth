using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seguimientoPersonaje : MonoBehaviour
{
    public GameObject personaje;
    private float posicion;
    // Start is called before the first frame update
    void Start()
    {
        posicion = transform.position.x - personaje.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(personaje.transform.position.x + posicion,transform.position.y,transform.position.z);
    }
}
