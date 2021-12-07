using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonic : MonoBehaviour
{
    public float Velocidade;
    public int Aneis;
    public AudioClip AudioPulo;
    public LayerMask Solo;
    public Transform ChecadorDeSolo;
    bool estanochao;
    bool estapulando;
    bool animacao;
    public float ForcaDePulo;
    public float AnguloDeContato;

    void Update()
    {
         Rigidbody2D Sonic = GetComponent<Rigidbody2D>();
        estanochao = Physics2D.OverlapCircle(ChecadorDeSolo.position, AnguloDeContato, Solo);
        if(estanochao)
         {
            animacao = true;
         }
        else
         {
            animacao = false;
         }
        if(animacao)
         {
            GetComponent<Animator>().SetBool("pulando", false);
         }
        else
         {
            GetComponent<Animator>().SetBool("pulando", true);
            GetComponent<Animator>().SetBool("andando", false);
               
         }
        if (Input.GetButtonDown("Jump") && estanochao)
         {
            estapulando = true;
            GetComponent<AudioSource>().PlayOneShot(AudioPulo);
         }
        if (estapulando)
         {
            Sonic.AddForce(new Vector2(0, ForcaDePulo));
            estapulando = false;
         }
        Rigidbody2D Walk = GetComponent<Rigidbody2D>();
        float hori = Input.GetAxis("Horizontal");

        Walk.velocity = new Vector2(hori * Velocidade, Walk.velocity.y);
        if(hori>0)
        {
            GetComponent<SpriteRenderer>().flipX = true;

        }
        else if (hori<0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if(hori >0 || hori <0)
        {
            GetComponent<Animator>().SetBool("andando", true);
        }
        else 
        {

            GetComponent<Animator>().SetBool("andando", false);

        }
       
    }
    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.CompareTag("anel"))
        {
            Aneis++;
        }
    }
    private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(ChecadorDeSolo.transform.position, AnguloDeContato);
        }
}
