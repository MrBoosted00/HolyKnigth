using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto : MonoBehaviour
{
    public Animator animator;
    public float visionRadius;
    public bool muerto;
    public float vel;

    private AudioSource audioPlayer;



    //Variable para guardar el jugador
    GameObject player;

    //Variable en la que guardamos la posicion inicial
    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");


        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //Por defecto nuestro objetivo sera la posicion inicial
        Vector3 target = initialPosition;

        if (muerto)
        {
            vel = 0;
            muerte();            
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
        if (dist < visionRadius && !player.GetComponent<Personaje>().getJump())
        {

            target = player.transform.position;

            animator.SetBool("Esqueleto", true);
            float fixedSpeed = vel * Time.deltaTime;


            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.x,transform.position.y,0), fixedSpeed);
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
        Invoke("terminarMuerte", 0.50f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
    }
}