using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dylan : MonoBehaviour
{

    public float Speed;
    public float JumpForce;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        Move();
    }

    void Move()
    {
        Vector2 movement = transform.position;
        movement.x += Input.GetAxis("Horizontal") * Speed;
        transform.position = movement;
    }
}
