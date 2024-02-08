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
    private Animator anim;
    private SpriteRenderer sprite;

    private enum jumpAnime { musuh_idle, musuh_movement, musuh_jump, no_animation };
    private jumpAnime state = jumpAnime.musuh_idle;
    private jumpAnime previousState; // Menyimpan state animasi sebelum terkena bola

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(AutoJumpAndMove());
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateAnimasi();
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
        previousState = state; // Simpan state animasi sebelum terkena bola
        state = jumpAnime.musuh_movement;
        StartCoroutine(StunTimer());
    }

    IEnumerator StunTimer()
    {
        yield return new WaitForSeconds(stunTimer);
        isStunned = false;
        state = previousState; // Kembalikan state animasi ke keadaan sebelumnya setelah stun selesai
    }

    void UpdateAnimasi()
    {
        // Periksa apakah state adalah no_animation untuk menentukan apakah animasi harus dijalankan
        if (state != jumpAnime.no_animation)
        {
            // Periksa apakah kecepatan horizontal lebih besar dari 0.1 untuk menentukan gerakan
            if (Mathf.Abs(rb.velocity.x) > 0.1f)
            {
                state = jumpAnime.musuh_movement;
            }
            else if (isStunned)
            {
                state = jumpAnime.musuh_idle;
            }
            else
            {
                state = jumpAnime.musuh_jump;
            }
        }
        anim.SetInteger("state", (int)state);
    }
}
