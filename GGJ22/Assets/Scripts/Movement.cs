using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10f;
    public float smoothSpeed = 5f;
    private Rigidbody2D rigidbody2d;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 moveDirection = new Vector2(horizontal, vertical);
        Vector2 velocity = moveDirection.normalized * speed * Time.deltaTime;
        Vector2 smoothedVelocity = Vector2.Lerp(rigidbody2d.velocity, velocity, smoothSpeed * Time.deltaTime);

        rigidbody2d.velocity = smoothedVelocity;
    }
}
