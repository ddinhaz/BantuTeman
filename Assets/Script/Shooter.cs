using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public Text cooldownText;
    public float cooldownDuration = 3f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;

    private bool isCooldown = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Menggunakan tombol Enter
        {
            if (!isCooldown)
            {
                Shoot();
                isCooldown = true;

                StartCoroutine(CooldownCoroutine());
            }
            else
            {
                cooldownText.text = "Sedang cooldown.";
            }
        }
    }

    IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(cooldownDuration);

        isCooldown = false;
        cooldownText.text = "";
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * bulletSpeed;

        Destroy(bullet, 0.5f);
    }
}
