using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour {
    GameObject enemigo;
    // Start is called before the first frame update
    void Start () {
        Destroy (gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update () {

    }

    private void OnTriggerEnter2D (Collider2D _col) {
        if (_col.gameObject.tag == "Esqueleto") {
            enemigo = _col.gameObject;
            Invoke ("muerteEnemigo", 0.2f);
        }
        if (_col.gameObject.tag == "Mago") {
            enemigo = _col.gameObject;
            Invoke ("muerteEnemigo", 0.3f);
        }
        if (_col.gameObject.tag == "Boss") {
            enemigo = _col.gameObject;
            Invoke ("muerteEnemigo", 0.3f);
        }
    }

    private void muerteEnemigo () {
        if (enemigo.gameObject.tag == "Esqueleto") {
            enemigo.GetComponent<Esqueleto> ().muerto = true;
        } else if (enemigo.gameObject.tag == "Mago") {
            enemigo.GetComponent<Mago> ().muerto = true;
        } else if (enemigo.gameObject.tag == "Boss") {
            enemigo.GetComponent<Boss> ().vidas--;
            enemigo.GetComponent<Boss> ().teletransporte = 0;
            if (enemigo.GetComponent<Boss> ().vidas > 0) {
                if (enemigo.transform.position.x == 35) {
                    enemigo.transform.position = new Vector3 (enemigo.transform.position.x - 17, enemigo.transform.position.y, 0);
                } else {
                    enemigo.transform.position = new Vector3 (enemigo.transform.position.x + 17, enemigo.transform.position.y, 0);
                }
            }
        }

    }

}