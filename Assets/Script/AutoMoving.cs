using UnityEngine;

public class AutoMoving : MonoBehaviour
{
    public float MoveSpeed = 3f;
    private bool moveRight = true;

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * MoveSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Mengubah arah pergerakan jika menyentuh objek dengan tag "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            moveRight = !moveRight; // Putar balik arah pergerakan
        }
    }
}
