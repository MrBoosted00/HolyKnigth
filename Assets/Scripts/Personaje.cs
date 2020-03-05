using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personaje : MonoBehaviour {
    private bool jump, atack, hit, shield;
    public float speed = 5f;
    private float hInput;
    public static int vidas = 3;
    public GameObject ataque, escudo;
    public GameObject posicionAccion;
    public Animator animator, transicion;
    private vidas vida_canvas;

    public bool btnDer = false;
    public bool btnIzq = false;

    private AudioSource audioPlayer;
    public AudioClip jumpClip;
    public AudioClip swordClip;
    public AudioClip hitClip;
    public AudioClip dieClip;

    // Start is called before the first frame update
    void Start () {
        audioPlayer = GetComponent<AudioSource> ();
        vida_canvas = GameObject.FindObjectOfType<vidas> ();
        vidas = 3;
    }

    // Update is called once per frame
    void Update () {
        vida_canvas.CambioVida (vidas);
        hInput = Input.GetAxis ("Horizontal");
        float vInput = Input.GetAxis ("Vertical");
        this.transform.position += new Vector3 (hInput * speed * Time.deltaTime, 0, 0);
        if (hInput < 0) {
            animator.SetBool ("Corriendo", true);
            transform.localRotation = Quaternion.Euler (0, 180, 0);
        } else if (hInput > 0) {
            animator.SetBool ("Corriendo", true);
            transform.localRotation = Quaternion.Euler (0, 0, 0);
        } else {
            animator.SetBool ("Corriendo", false);
        }

        if (Input.GetKeyDown (KeyCode.W)) {
            saltar ();
        }

        if (Input.GetKeyDown (KeyCode.Space) || Input.GetButton ("Fire1")) {
            atacar ();
        }

        if (Input.GetKeyDown (KeyCode.Q)) {
            proteger ();
        }

        if (btnDer) {

            //this.transform.position += new Vector3 (hInput * speed * Time.deltaTime, 0, 0);
            this.transform.Translate (Vector3.right * Time.deltaTime * speed);

            animator.SetBool ("Corriendo", true);
            transform.localRotation = Quaternion.Euler (0, 0, 0);

        }

        if (btnIzq) {

            //this.transform.position += new Vector3 (hInput * speed * Time.deltaTime, 0, 0);
            this.transform.Translate (Vector3.right * Time.deltaTime * speed);

            animator.SetBool ("Corriendo", true);
            transform.localRotation = Quaternion.Euler (0, 180, 0);

        }

    }

    public void moverseDer () {
        btnDer = true;

    }
    public void moverseIzq () {
        btnIzq = true;
    }

    public void detener () {
        btnDer = false;
        btnIzq = false;
    }

    public void saltar () {
        if (!jump && !hit && !atack && !shield) {
            Debug.Log ("saltando");
            GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0.0f, 395.0f));
            jump = true;
            animator.SetBool ("Saltar", true);

            audioPlayer.clip = jumpClip;
            audioPlayer.Play ();
        }
    }

    void OnCollisionEnter2D (Collision2D _col) {
        if (_col.gameObject.tag == "suelo") {
            animator.SetBool ("Saltar", false);
            jump = false;

        }

        if (_col.gameObject.tag == "puerta") {
            StartCoroutine ("CargarIglesia");
        }
        if (_col.gameObject.tag == "puerta2") {
            StartCoroutine ("CargarFinalBoss");
        }

        if (_col.gameObject.tag == "Esqueleto") {
            speed = 5;
            hit = true;
            vidas--;
            vida_canvas.CambioVida (vidas);
            animator.SetBool ("Hiteado", true);
            Debug.Log ("Vidas: " + vidas);

            if (_col.gameObject.transform.position.x - transform.position.x > 0) {
                GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-250.0f, 0f));
            } else {
                GetComponent<Rigidbody2D> ().AddForce (new Vector2 (250.0f, 0f));
            }
            if (vidas <= 0) {
                audioPlayer.clip = dieClip;
                audioPlayer.Play ();

                animator.SetTrigger ("Muerte");
                speed = 0;
                Invoke ("terminarMuerte", 1.2f);

            } else {
                Invoke ("terminarHit", 0.7f);
            }
        }

        if (_col.gameObject.tag == "Mago") {
            speed = 5;
            hit = true;
            vidas--;
            animator.SetBool ("Hiteado", true);
            Debug.Log ("Vidas: " + vidas);

            if (_col.gameObject.transform.position.x - transform.position.x > 0) {
                GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-150.0f, 0f));
            } else {
                GetComponent<Rigidbody2D> ().AddForce (new Vector2 (150.0f, 0f));
            }
            if (vidas <= 0) {
                animator.SetTrigger ("Muerte");
                speed = 0;
                audioPlayer.clip = dieClip;
                audioPlayer.Play ();
                Invoke ("terminarMuerte", 1.2f);

            } else {
                Invoke ("terminarHit", 0.7f);
            }
        }

        if (_col.gameObject.tag == "Boss") {
            speed = 5;
            hit = true;
            vidas--;
            vida_canvas.CambioVida (vidas);
            animator.SetBool ("Hiteado", true);
            Debug.Log ("Vidas: " + vidas);

            if (_col.gameObject.transform.position.x - transform.position.x > 0) {
                GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-350.0f, 0f));
            } else {
                GetComponent<Rigidbody2D> ().AddForce (new Vector2 (350.0f, 0f));
            }
            if (vidas <= 0) {
                audioPlayer.clip = dieClip;
                audioPlayer.Play ();

                animator.SetTrigger ("Muerte");
                speed = 0;
                Invoke ("terminarMuerte", 1.2f);

            } else {
                Invoke ("terminarHit", 0.7f);
            }
        }

        if (_col.gameObject.tag == "Hechizo") {
            Destroy (_col.gameObject, 0.1f);
            speed = 5;
            hit = true;
            vidas--;
            animator.SetBool ("Hiteado", true);

            audioPlayer.clip = hitClip;
            audioPlayer.Play ();

            if (_col.gameObject.transform.position.x - transform.position.x > 0) {
                GetComponent<Rigidbody2D> ().AddForce (new Vector2 (-150.0f, 0f));
            } else {
                GetComponent<Rigidbody2D> ().AddForce (new Vector2 (150.0f, 0f));
            }
            if (vidas <= 0) {
                audioPlayer.clip = dieClip;
                audioPlayer.Play ();
                animator.SetTrigger ("Muerte");
                speed = 0;
                Invoke ("terminarMuerte", 1.2f);

            } else {
                Invoke ("terminarHit", 0.7f);
            }
        }

        if (_col.gameObject.tag == "Pinchos") {
            audioPlayer.clip = dieClip;
            audioPlayer.Play ();
            animator.SetBool ("Hiteado", true);
            animator.SetTrigger ("Muerte");
            speed = 0;
            Invoke ("terminarMuerte", 1.2f);

        }
    }

    IEnumerator CargarIglesia () {
        transicion.SetTrigger ("Salida");
        speed = 0;
        yield return new WaitForSeconds (0.5f);
        SceneManager.LoadScene (2);
    }

    IEnumerator CargarFinalBoss () {
        transicion.SetTrigger ("Salida");
        speed = 0;
        yield return new WaitForSeconds (0.7f);
        SceneManager.LoadScene (3);
    }

    public float gethInput () {
        return hInput;
    }

    public bool getJump () {
        return jump;
    }

    private void atacar () {
        if (!atack && !hit && !jump && !shield) {
            animator.SetTrigger ("Atacar");
            GameObject.Instantiate (ataque, posicionAccion.transform.position,
                posicionAccion.transform.rotation);
            atack = true;
            speed = 0;
            Invoke ("terminarAtaque", 0.7f);

            audioPlayer.clip = swordClip;
            audioPlayer.Play ();
        }
    }

    public void atacarBtn () {
        atacar ();
    }

    private void proteger () {
        if (!atack && !hit && !jump && !shield) {
            animator.SetTrigger ("Escudo");
            GameObject.Instantiate (escudo, posicionAccion.transform.position,
                posicionAccion.transform.rotation);
            shield = true;
            speed = 0;
            Invoke ("terminarProteger", 0.7f);
        }
    }

    public void protegerBtn () {
        proteger ();
    }

    private void terminarAtaque () {
        atack = false;
        speed = 5;
    }

    private void terminarProteger () {
        shield = false;
        speed = 5;
    }

    private void terminarHit () {
        hit = false;
        animator.SetBool ("Hiteado", false);
        speed = 5;
    }

    private void terminarMuerte () {

        gameObject.SetActive (false);
        SceneManager.LoadScene (0);
    }
}