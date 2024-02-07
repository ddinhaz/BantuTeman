using System.Collections;
using UnityEngine;

public class MovementMusuh : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D rb;
    public float JumpForce;
    public float JumpDelay = 0.5f;

    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Mulai coroutine untuk melompat dan bergerak
        StartCoroutine(AutoJumpAndMove());
    }

    IEnumerator AutoJumpAndMove()
    {
        while (true) // Melakukan looping agar karakter terus melompat dan bergerak
        {
            // Melakukan lompatan
            rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            isJumping = true;

            // Memberikan jeda
            yield return new WaitForSeconds(JumpDelay);

            // Memberikan kecepatan maju setelah jeda
            rb.velocity = new Vector2(MoveSpeed, rb.velocity.y);

            // Menunggu sampai karakter menyentuh tanah lagi sebelum melompat lagi
            yield return new WaitUntil(() => isJumping == false);
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
