using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour {
    bool active;
    public Animator animator;
    Canvas canvas;
    void Start () {
        canvas = GetComponent<Canvas> ();
        canvas.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown ("escape")) {
            Pausar ();

        }
    }

    public void Reanudar () {
        active = !active;
        canvas.enabled = active;
        Time.timeScale = (active) ? 0 : 1f;
    }

    public void Salir () {
        active = !active;
        canvas.enabled = active;
        Time.timeScale = (active) ? 0 : 1f;
        StartCoroutine ("CargarMenu");
    }

    public void Pausar () {
        active = !active;
        canvas.enabled = active;
        Time.timeScale = (active) ? 0 : 1f;
    }

    IEnumerator CargarMenu () {
        animator.SetTrigger ("Salida");
        yield return new WaitForSeconds (0.8f);
        SceneManager.LoadScene (0);
    }
}