using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;


    public float xMax;
    public float xMin;
    public float yMax;
    public float yMin;
    private float cameraSpeed = 0.05f;
    private float urgencySpeed = 8f;
    public bool urgencyCamera = false;

    //Mathf.Clamp(player.transform.position.x,xMin,xMax)
    public int currentY;
    public int currentX;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Math.Abs(transform.position.y - player.transform.position.y) > 2)
        {
            currentY = (int)player.transform.position.y + 2;
            if (Math.Abs(transform.position.y - player.transform.position.y) > 8.5)
            {
                urgencyCamera = true;
            }
            else
            {
                urgencyCamera = false;
            }
        }

        if (Math.Abs(transform.position.x - player.transform.position.x) > 8)
        {
            var calculation = transform.position.x - player.transform.position.x > 0 ? 8 : -8;
            currentX = (int)player.transform.position.x + calculation;
        }

        //MoveInstantly();
        MoveSlowly();
    }

    public void MoveInstantly()
    {
        var pos = transform.position;
        pos.x = currentX;
        transform.position = pos;
    }

    public void MoveSlowly()
    {
        var pos = transform.position;
        if (pos.x <= xMin)
        {
            pos.x = pos.x + 0.0003f;
            SetPosition(pos);
            return;
        }
        
        if(pos.x >= xMax)
        {
            pos.x = pos.x - 0.0003f;
            SetPosition(pos);
            return;
        }

        if (currentX > (int)pos.x)
        {
            pos.x += cameraSpeed;
        }
        else if (currentX < (int)pos.x)
        {
            pos.x -= cameraSpeed;
        }

        //if (currentY > (int)pos.y)
        //{
        //    pos.y += !urgencyCamera ? cameraSpeed : cameraSpeed * urgencySpeed;
        //}
        //else if (currentY < (int)pos.y)
        //{
        //    pos.y -= !urgencyCamera ? cameraSpeed : cameraSpeed * urgencySpeed;
        //}
        SetPosition(pos);
    }

    private void SetPosition(Vector3 pos)
    {
        transform.position = pos;
    }

    public void CameraReset()
    {
        var pos = transform.position;
        pos.x = player.transform.position.x;
        pos.y = player.transform.position.y;
        transform.position = pos;
    }
}
