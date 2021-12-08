using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knuckels : MonoBehaviour
{

    public float velocidadeMax = 20;
    public float multiplicadorAnalogico = 0.43f;
    public float aceleracao = 1.4f;
    private Animator animator;
    private Rigidbody2D player;
    private SpriteRenderer sprite;
    public LayerMask Solo;
    public Transform ChecadorDeSolo;
    bool EstaNoChao;
    bool EstaPulando;
    public float ForcaDoPulo;
    public float AnguloDeContato;
    bool estaSocando = false;
    bool animacao;

    public float velocidadeAtual = 0;
    public float animationSpeed = 0.1f;
    public float animationMultiplicator = 0.1f;
    public float minAnimationSpeed = 0.5f;
    private float baseAnimationSpeed = 1f;

    private bool isMaxSpeed = false;
    public float maxSpeedAnimationMultiplicator = 2.5f;

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
            Vector2 velocidadeAtual = player.velocity;

            bool andandoPraFrente = !sprite.flipX;

            if (
                (velocidadeAtual.x < velocidadeMax && andandoPraFrente) ||
                (velocidadeAtual.x > -velocidadeMax && !andandoPraFrente)
                )
            {
                player.AddForce(new Vector2(hori * (aceleracao), 0));

                this.velocidadeAtual = velocidadeAtual.x;
            }

            isMaxSpeed = Math.Abs(velocidadeAtual.x) > velocidadeMax - 3;

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

        if (animator.GetBool("andando"))
        {
            var newSpeedAnimation = (float)Math.Abs(Math.Round(player.velocity.x)) * animationMultiplicator;

            if (isMaxSpeed)
                newSpeedAnimation *= maxSpeedAnimationMultiplicator;

            if (newSpeedAnimation < minAnimationSpeed)
            {
                newSpeedAnimation = minAnimationSpeed;
            }

            animator.speed = newSpeedAnimation;
        }
        if (estaSocando)
        {
            animator.speed = baseAnimationSpeed;
        }

        animationSpeed = animator.speed;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack1");
            estaSocando = true;
            player.velocity = Vector2.zero;
        }

        EstaNoChao = Physics2D.OverlapCircle(ChecadorDeSolo.position, AnguloDeContato, Solo);
        if (EstaNoChao)
        {
            animacao = true;
        }
        else
        {
            animacao = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack1");
            estaSocando = true;
            player.velocity = Vector2.zero;
        }

        EstaNoChao = Physics2D.OverlapCircle(ChecadorDeSolo.position, AnguloDeContato, Solo);
        if (EstaNoChao)
        {
            animacao = true;
        }
        else
        {
            animacao = false;
        }
        if (animacao)
        {
            animator.SetBool("pulo", false);
        }
        else
        {
            animator.SetBool("pulo", true);
            animator.SetBool("andando", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && EstaNoChao)
        {
            EstaPulando = true;
        }
        if (EstaPulando)
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
