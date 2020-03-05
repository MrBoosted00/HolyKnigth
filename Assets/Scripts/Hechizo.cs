using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hechizo : MonoBehaviour {

    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start () {
        Destroy(gameObject,3.2f);
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        float speed = 4f;
        rig.velocity = -transform.right*speed;
    }
}