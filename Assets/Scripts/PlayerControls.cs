using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode moveForward;
    public KeyCode moveBack;
    public float speed = 10f;
    public float boundY = 3f;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

  
    private void Movement()
    {
        var vel = rb2d.velocity;
        if (Input.GetKey(moveUp)) vel.y = speed;
        else if (Input.GetKey(moveDown)) vel.y = -speed;
        else if (Input.GetKey(moveForward)) vel.x = speed;  
        else if (Input.GetKey(moveBack)) vel.x = -speed;
        else 
        {
             vel.y = 0; 
             vel.x = 0;   
        }
        rb2d.velocity=vel;
    }

    private void Boundaries()
    {
        var pos = transform.position;
        if (pos.y > boundY) pos.y = boundY;
        else if (pos.y < -boundY) pos.y = -boundY;
        else if (pos.y > boundY) pos.x = boundY;
        else if (pos.y < -boundY) pos.x = -boundY;
        transform.position = pos;
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        Boundaries();
    }
}
