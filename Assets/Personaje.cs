using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {
    private bool jump, atack;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        float hInput = Input.GetAxis ("Horizontal");
        this.transform.position += new Vector3 (hInput * speed * Time.deltaTime, 0, 0);

        if (Input.GetKey (KeyCode.W)) {
            if (jump == false) {
                GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0.0f, 350.0f));
                jump = true;
            }
        }
    }

    void OnCollisionEnter2D (Collision2D _col) {
        if (_col.gameObject.tag == "suelo") {
            jump = false;
        }
    }
}