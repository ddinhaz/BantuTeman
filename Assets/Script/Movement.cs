using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D rb;
    public float JumpForce;

    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            isJumping = true;
            
            rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
