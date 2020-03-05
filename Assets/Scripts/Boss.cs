using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour {
    public Animator animator,transicion;
    private bool atack;
    public bool activar;
    public int vidas;
    public float visionRadius;
    public int ataques, teletransporte;
    public GameObject hechizo;
    public GameObject posicionHechizo;

    private AudioSource audioPlayer;
    public AudioClip fireBallClip;

    //Variable para guardar el jugador
    GameObject player;
    // Start is called before the first frame update
    void Start () {
        audioPlayer = GetComponent<AudioSource> ();
        vidas = 5;
        teletransporte = 0;
        ataques = 0;
        player = GameObject.FindGameObjectWithTag ("Player");
    }

    // Update is called once per frame
    void Update () {
        if (activar) {
            if (vidas <= 0) {
                muerte ();                
            } else if (teletransporte >= 3) {
                teletransporte = 0;
                if (transform.position.x == 35) {
                    transform.position = new Vector3 (transform.position.x - 17, transform.position.y, 0);
                } else {
                    transform.position = new Vector3 (transform.position.x + 17, transform.position.y, 0);
                }
            }

            if (player.transform.position.x - transform.position.x > 0) {
                transform.localRotation = Quaternion.Euler (0, 180, 0);
            }
            if (player.transform.position.x - transform.position.x < 0) {
                transform.localRotation = Quaternion.Euler (0, 0, 0);
            }
            float dist = Vector3.Distance (player.transform.position, transform.position);
            if (dist < visionRadius && vidas > 0) {

                atacar ();
            }
        }
    }

    private void reiniciarAtaques () {
        teletransporte++;
        atack = false;
        ataques = 0;
    }

    public void activate () {
        StartCoroutine ("iniciarBoss");
    }

    IEnumerator iniciarBoss () {
        animator.SetTrigger ("Entrar");
        yield return new WaitForSeconds (1.2f);
        activar = true;
    }

    private void terminarHechizo () {

        atack = false;
    }

    IEnumerator CargarCreditos () {
        transicion.SetTrigger ("Salida");
        yield return new WaitForSeconds (0.8f);
        SceneManager.LoadScene (6);
    }

    public void muerte () {
        animator.SetTrigger ("Muerto");
        StartCoroutine("CargarCreditos");
    }

    void OnDrawGizmos () {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere (transform.position, visionRadius);
    }

    private void atacar () {
        if (atack == false) {

            audioPlayer.clip = fireBallClip;
            audioPlayer.Play ();
            audioPlayer.volume = 1;

            animator.SetTrigger ("Atack");
            atack = true;
            Invoke ("lanzarHechizo", 0.5f);
            ataques++;
            if (ataques > 1) {
                Invoke ("reiniciarAtaques", 2.75f);
            } else {
                Invoke ("terminarHechizo", 0.75f);
            }
        }
    }

    private void lanzarHechizo () {
        GameObject.Instantiate (hechizo, posicionHechizo.transform.position,
            posicionHechizo.transform.rotation);
    }
}