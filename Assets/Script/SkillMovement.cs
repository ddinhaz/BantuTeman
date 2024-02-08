using UnityEngine;

public class SkillMovement : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    [SerializeField]
    public bool canJump = false;
    private bool hasJumped = false;
    public Collider2D area;
    public GameObject player;
    private Animator anim;
    private SpriteRenderer sprite; // Deklarasi SpriteRenderer

    private Rigidbody2D playerRb;
    private enum jumpAnim { player_idle, Playerr, player_run };
    private jumpAnim state = jumpAnim.player_idle;

    void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
        anim = player.GetComponent<Animator>(); // Mengambil Animator dari player
        sprite = GetComponent<SpriteRenderer>(); // Tetap inisialisasi SpriteRenderer
    }

    void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.Space) && canJump && !hasJumped)
        {
            UpdateAnimasi();
            JumpAction();

        }
    }

    void JumpAction()
    {
        state = jumpAnim.Playerr;
        playerRb.velocity = new Vector2(MoveSpeed, JumpForce);
        hasJumped = true;
        RandomizePosition();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("B"))
        {
            canJump = true;
            hasJumped = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("B"))
        {
            canJump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player && !collision.gameObject.CompareTag("Ground"))
        {
            hasJumped = false;
        }
    }

    public void RandomizePosition()
    {
        Bounds bounds = area.bounds;

        float areaWidth = bounds.max.x - bounds.min.x;
        float x = Random.Range(bounds.min.x, bounds.min.x + areaWidth);

        float y = transform.position.y; // Dapatkan nilai y dari posisi objek saat ini

    // Pembulatan nilai x agar posisi berada pada grid (opsional)
        x = Mathf.Round(x);

        transform.position = new Vector2(x, y);
    }

    void UpdateAnimasi()
    {
        if (hasJumped)
        {
            sprite.flipX = false;
            state = jumpAnim.Playerr;
            
        }
        else
        {
            state = jumpAnim.player_idle;
        }
        if (MoveSpeed > .1f)
        {
            state = jumpAnim.player_run;
        }
        anim.SetInteger("state", (int)state);
    }

}
