using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;
    public float shootingInterval = 0f;
    private float lastShotTime;
    private bool canShoot = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            canShoot = true;
        }

        if (canShoot)
        {
            if (Time.time - lastShotTime >= shootingInterval)
            {
                Shoot();
                lastShotTime = Time.time;
                canShoot = false;
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, 0));
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.velocity = -firePoint.up * bulletSpeed;
    }
}
