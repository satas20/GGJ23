using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed = 10f;
    public float runSpeed = 20f;
    public float speed;
    private Rigidbody2D rigidBody2D;
    private Animator animator;

    void Start()
    {
        speed = 10f;
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
        Vector2 direction = new Vector2(horizontal, vertical);
        rigidBody2D.velocity = direction * speed;
        
    }
}