using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knuckels : MonoBehaviour
{

    public float Velocidade;
    private Animator animator;
    private Rigidbody2D player;
    private SpriteRenderer sprite;

    bool estaSocando = false;

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
        }

        if (hori > 0)
        {
            sprite.flipX = false;
        }
        else if (hori < 0)
        {
            sprite.flipX = true;
        }

        if (hori > 0 || hori < 0)
        {
            animator.SetBool("andando", true);
        }
        else
        {
            animator.SetBool("andando", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack1");
            estaSocando = true;
            player.velocity = Vector2.zero;
        }
    }
    public void FimDoSoco()
    {
        estaSocando = false;
    }
}
