using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {
    private bool jump, atack;
    public float speed = 5f;
    public GameObject ataque;
    public GameObject posicionAtaque;
    public Animator animator;

    // Start is called before the first frame update
    void Start () {
    }

    // Update is called once per frame
    void Update () {        
        float hInput = Input.GetAxis ("Horizontal");
        this.transform.position += new Vector3 (hInput * speed * Time.deltaTime, 0, 0);



        if (hInput < 0)
        {
            animator.SetBool("Corriendo",true); 
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if(hInput > 0)
        {
            animator.SetBool("Corriendo",true); 
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }else{
            animator.SetBool("Corriendo",false);
        }

        if (Input.GetKeyDown(KeyCode.W)) {
            if (jump == false) {
                GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0.0f, 350.0f));
                jump = true;

                animator.SetBool("Saltar",true);
            }
        }

        if(Input.GetKeyDown(KeyCode.Space)){            
            atacar();
        }
    }

    void OnCollisionEnter2D (Collision2D _col) {
        if (_col.gameObject.tag == "suelo") {
            animator.SetBool("Saltar",false);
            jump = false;
        }
    }

    public void atacar()
    {
        // Si no estamos atacando ya (para no pulsar contínuamente)
        if (atack == false)
        {
            // Creamos el ataque en la posición de ataque.
            GameObject.Instantiate(ataque, posicionAtaque.transform.position, 
            posicionAtaque.transform.rotation);
            atack = true;
            speed = 0;
            animator.SetTrigger("Atacar");
            Invoke("terminarAtaque", 0.7f);
        }
    }

    private void terminarAtaque () {
        atack = false;
        speed = 5;
    }
}