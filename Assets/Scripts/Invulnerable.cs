using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invulnerable : MonoBehaviour
{
    Renderer rend;
    Color c;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.tag == "Enemigo" && Personaje.vidas > 0){
            StartCoroutine("GetInvulnerable");  
        }
    }

    IEnumerator GetInvulnerable(){
        Physics2D.IgnoreLayerCollision(8,9,true);
        yield return new WaitForSeconds(3f);
        Physics2D.IgnoreLayerCollision(8,9,true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
