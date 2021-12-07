using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knuckels : MonoBehaviour
{

    public float Velocidade;
    private Animator animator;
    private Rigidbody2D player;
    private SpriteRenderer sprite;
    public LayerMask Solo;
    public Transform ChecadorDeSolo;
    bool EstaNoChao;
    bool EstaPulando;
    public float ForcaDoPulo;
    public float AnguloDeContato;
    bool estaSocando;
    bool animacao;



    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");

        //!estasocando - estasocando == false
        if (!estaSocando)
        {
            player.velocity = new Vector2(hori * Velocidade, player.velocity.y);

            if (hori > 0 || hori < 0)
            {
                animator.SetBool("andando", true);
            }
            else
            {
                animator.SetBool("andando", false);
            }

            if (hori > 0)
            {
                sprite.flipX = false;
            }
            else if (hori < 0)
            {
                sprite.flipX = true;
            }
        }
       
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack1");
            estaSocando = true;
            player.velocity = Vector2.zero;
        }

        EstaNoChao = Physics2D.OverlapCircle(ChecadorDeSolo.position, AnguloDeContato, Solo);
        if(EstaNoChao)
        {
            animacao = true;
        }
        else
        {
            animacao = false;
        }
        if(animacao)
        {
            animator.SetBool("pulo", false);
        }
        else
        {
            animator.SetBool("pulo", true);
            animator.SetBool("andando", false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && EstaNoChao)
        {
            EstaPulando = true;
        }
        if(EstaPulando)
        {
            player.AddForce(new Vector2(0, ForcaDoPulo));
            EstaPulando = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ChecadorDeSolo.transform.position, AnguloDeContato);
    }
    public void FimDoSoco()
    {
        estaSocando = false;
    }
}
