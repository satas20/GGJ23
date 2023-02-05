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
    private float horizontal;
    private float vertical;


    void Start()
    {
        speed = 10f;
        rigidBody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            animator.SetBool("IsRunning", true);
        }
        else
        {
            speed = walkSpeed;
            animator.SetBool("IsRunning", false);

        }
        
    }

    private void FixedUpdate()
    {



        Vector2 direction = new Vector2(horizontal, vertical);
        
        rigidBody2D.velocity = direction * speed;
        
        if (direction.magnitude > 0) {
            animator.SetBool("IsWalking", true); 
            rigidBody2D.angularVelocity = 0;

        }
        else
        {
            animator.SetBool("IsWalking", false);
            rigidBody2D.velocity *= 0;
            rigidBody2D.angularVelocity = 0;
        }
    }
}