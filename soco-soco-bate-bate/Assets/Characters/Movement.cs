using Assets.Enums;
using Assets.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private float speed = 55f;

    public bool isFlipped = false;
    public bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = 0;
        float y = 0;
        if (AnyUpKeyPressed())
        {
            y = y + speed;
        }
        if (AnyDownKeyPressed())
        {
            y = y - speed;
        }
        if(AnyLeftKeyPressed())
        {
            x = x - speed;
        }
        if(AnyRightKeyPressed())
        {
            x = x + speed;
        }
        Vector3 tempVect = new Vector2(x, y);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + tempVect);

        if (tempVect.x == 0 && tempVect.y == 0)
        {
            isWalking = false;
            animator.SetBool("IsWalking", isWalking);
        }
        else
        {
            isWalking = true;
            animator.SetBool("IsWalking", true);
        }

        if(x < 0)
        {
            Flip(Direction.Left);
        }
        if(x > 0)
        {
            Flip(Direction.Right);
        }
    }

    private bool AnyUpKeyPressed()
    {
        List<KeyCode> upKeys = new List<KeyCode>()
        {
            KeyCode.UpArrow,
            KeyCode.W
        };

        bool pressed = false;
        foreach(var key in upKeys)
        {
            pressed = Input.GetKey(key);

            if (pressed == true)
                break;
        }

        return pressed;
    }

    private bool AnyDownKeyPressed()
    {
        List<KeyCode> upKeys = new List<KeyCode>()
        {
            KeyCode.DownArrow,
            KeyCode.S
        };

        bool pressed = false;
        foreach (var key in upKeys)
        {
            pressed = Input.GetKey(key);

            if (pressed == true)
                break;
        }

        return pressed;
    }

    private bool AnyRightKeyPressed()
    {
        List<KeyCode> upKeys = new List<KeyCode>()
        {
            KeyCode.RightArrow,
            KeyCode.D
        };

        bool pressed = false;
        foreach (var key in upKeys)
        {
            pressed = Input.GetKey(key);

            if (pressed == true)
                break;
        }

        return pressed;
    }

    private bool AnyLeftKeyPressed()
    {
        List<KeyCode> upKeys = new List<KeyCode>()
        {
            KeyCode.LeftArrow,
            KeyCode.A
        };

        bool pressed = false;
        foreach (var key in upKeys)
        {
            pressed = Input.GetKey(key);

            if (pressed == true)
                break;
        }

        return pressed;
    }

    public void Flip(Direction dir)
    {
        if (dir == Direction.Left)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
            isFlipped = true;
        }

        if (dir == Direction.Right)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            isFlipped = false;
        }
    }
}
