using Assets.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 55f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
