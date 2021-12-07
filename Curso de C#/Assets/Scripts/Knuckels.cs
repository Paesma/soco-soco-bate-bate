using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knuckels : MonoBehaviour
{
    
    public float Velocidade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D Player = GetComponent<Rigidbody2D>();
        float hori = Input.GetAxis("Horizontal");
        Player.velocity = new Vector2(hori * Velocidade, Player.velocity.y);

        if(hori>0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(hori<0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
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
}
