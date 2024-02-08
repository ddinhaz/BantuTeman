using UnityEngine;

public class SkillMovement : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpForce;
    private bool canJump = false;
    private bool hasJumped = false;
    public Collider2D area;
    public GameObject player;

    private Rigidbody2D playerRb;

    void Start()
    {
        playerRb = player.GetComponent<Rigidbody2D>();
    }
 
    void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.UpArrow) && canJump && !hasJumped)
        {
            Jump();
        }
    }

    void Jump()
    {
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

        float y = transform.position.y;
        float x = Random.Range(bounds.min.x, bounds.max.x);

        x = Mathf.Round(x);

        transform.position = new Vector2(x, y);
    }
}
