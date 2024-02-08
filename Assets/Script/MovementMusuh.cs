using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MovementMusuh : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D rb;
    public float JumpForce;
    public float JumpDelay = 0.5f;
    private bool isStunned = false;
    private float stunTimer = 0f;
    public float stunDuration = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(AutoJumpAndMove());
    }

    IEnumerator AutoJumpAndMove()
    {
        while (true)
        {
            if (!isStunned)
            {
                rb.velocity = new Vector2(MoveSpeed, JumpForce);
            }
            else
            {
                rb.velocity = Vector2.zero;
            }

            yield return new WaitForSeconds(JumpDelay);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bola"))
        {
            Stun(stunDuration);
            Destroy(other.gameObject); // Menghancurkan objek bola yang menyentuh musuh
        }
    }

    void Stun(float duration)
    {
        isStunned = true;
        stunTimer = duration;
        StartCoroutine(StunTimer());
    }

    IEnumerator StunTimer()
    {
        yield return new WaitForSeconds(stunTimer);
        isStunned = false;
    }
}
