using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vidas : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite [] corazones;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambioVida (int pos){
        this.GetComponent <Image>().sprite=corazones [pos];
    }
}
