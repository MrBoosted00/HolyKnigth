using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plataforma : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject menu;
    public Button button;
    public Button button2;
    public Button button3;

    public Button button4;
    public Button button5;
    public Button button6;

    Canvas canvas;
    void Start()
    {
        canvas = GetComponent<Canvas>();
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            button.gameObject.SetActive(false);
            button2.gameObject.SetActive(false);
            button3.gameObject.SetActive(false);
            button4.gameObject.SetActive(false);
            button5.gameObject.SetActive(false);
            button6.gameObject.SetActive(false);
            //menu.gameObject.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {


    }

    /*void Hide () {
        menu.alpha = 0f; //this makes everything transparent
        menu.blocksRaycasts = false; //this prevents the UI element to receive input events
    }*/
}