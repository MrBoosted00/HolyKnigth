using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos_Volver : MonoBehaviour {
    // Start is called before the first frame update
    public Animator animator;
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown ("escape")) {
            volver ();
        }

    }

    public void volver () {
        StartCoroutine("CargarMenu");
    }

    IEnumerator CargarMenu () {
        animator.SetTrigger ("Salida");
        yield return new WaitForSeconds (0.8f);
        SceneManager.LoadScene (0);
    }
}