using Assets.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour
{
    private Direction direction;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var x = direction == Direction.Left ? -1 : +1;
        Vector3 tempVect = new Vector2(x, 0);
        tempVect = tempVect.normalized * speed * Time.deltaTime;
        GetComponent<Rigidbody2D>().MovePosition(transform.position + tempVect);

        transform.Rotate(new Vector3(0, 0, 1));
    }

    public void SetDirection(Direction direction)
    {
        this.direction = direction;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
