using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    GameObject hechizo;
    Animator animator;

    private AudioSource audioPlayer;
    public AudioClip shieldBlastCLip;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        animator = GameObject.FindWithTag("Body").GetComponent<Animator>();
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D _col)
    {
        if (_col.gameObject.tag == "Hechizo")
        {
            hechizo = _col.gameObject;
            animator.SetTrigger("EscudoHit");

            audioPlayer.clip = shieldBlastCLip;
            audioPlayer.Play();

            Destroy(hechizo, 0);
        }
    }
}