using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mago : MonoBehaviour
{
    public Animator animator;
    private bool atack;
    public float visionRadius;
    public GameObject hechizo;
    public GameObject posicionHechizo;
    public bool muerto;

    //Variable para guardar el jugador
    GameObject player;


    private AudioSource audioPlayer;
    public AudioClip fireBallClip;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        if (muerto)
        {
            muerte();
            Invoke("terminarMuerte", 0.4f);
        }
        if (player.transform.position.x - transform.position.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (player.transform.position.x - transform.position.x < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist < visionRadius && !muerto)
        {
            atacar();
        }
    }

    IEnumerator terminarHechizo()
    {
        audioPlayer.clip = fireBallClip;
        audioPlayer.Play();
        animator.SetTrigger("Ataque");
        atack = true;
        GameObject.Instantiate(hechizo, posicionHechizo.transform.position,
            posicionHechizo.transform.rotation);
        yield return new WaitForSeconds(2.5f);
        atack = false;
        if (muerto)
        {
            atack = true;
        }
    }

    private void terminarMuerte()
    {
        gameObject.SetActive(false);
        Destroy(gameObject, 1f);
    }

    public void muerte()
    {
        animator.SetTrigger("Muerto");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }

    private void atacar()
    {
        if (atack == false)
        {

            StartCoroutine("terminarHechizo");
        }
    }
}