using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jugar : MonoBehaviour {
    // Start is called before the first frame update
    public Animator animator;
    void Start () {

    }

    // Update is called once per frame
    void Update () {

    }

    public void Play () {
        StartCoroutine ("CargarJuego");
    }

    public void Creditos () {
        StartCoroutine ("CargarCreditos");
    }

    public void Salir () {
        Application.Quit ();
    }
    public void Historia () {
        StartCoroutine ("CargarHistoria");
    }

    IEnumerator CargarJuego () {
        animator.SetTrigger ("Salida");
        yield return new WaitForSeconds (0.8f);
        SceneManager.LoadScene (1);
    }

    IEnumerator CargarCreditos () {
        animator.SetTrigger ("Salida");
        yield return new WaitForSeconds (0.8f);
        SceneManager.LoadScene (4);
    }

    IEnumerator CargarHistoria () {
        animator.SetTrigger ("Salida");
        yield return new WaitForSeconds (0.8f);
        SceneManager.LoadScene (5);
    }
}