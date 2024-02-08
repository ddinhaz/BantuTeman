using UnityEngine;

public class SkillShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;
    private bool canShoot = false;
    public Collider2D gridArea;
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && canShoot)
        {
            Shoot();
            RandomizePosition();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("B"))
        {
            canShoot = true;
        }
       
    }

    void OnTriggerExit2D(Collider2D other)
    {
       
        if (other.CompareTag("B"))
        {
            canShoot = false;
        }
    }

    public void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        float y = transform.position.y;
        float x = Random.Range(bounds.min.x, bounds.max.x);

        x = Mathf.Round(x);

        transform.position = new Vector2(x, y);
    }


    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * bulletSpeed;

        Destroy(bullet, 0.5f);

        
    }
}
