using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject boxPrefab; // Prefab objek kotak yang ingin ditampilkan
    public Transform firePoint;
    public float bulletSpeed = 15f;
    public float cooldownTime = 4f; // Waktu cooldown dalam detik

    [SerializeField]
    private float lastFireTime; // Waktu terakhir menembak

    void Start()
    {
        lastFireTime = -cooldownTime; // Set waktu terakhir menembak agar bisa menembak pertama kali
    }

    void Update()
    {
        // Mengecek apakah sudah melewati waktu cooldown sejak tembakan terakhir
        if (Input.GetKeyDown(KeyCode.Return) && Time.time - lastFireTime >= cooldownTime)
        {
            RenderBoxAtFirePoint(); // Panggil fungsi untuk merender kotak di tempat tembak
            lastFireTime = Time.time; // Update waktu terakhir menembak
        }
    }

    public void RenderBoxAtFirePoint()
    {
        GameObject box = Instantiate(boxPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = box.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * bulletSpeed;

    }

    private void OnTriggerEnter2D (Collider2D other)
    {
        if(CompareTag("Enemy") || CompareTag("Ground"))
        {
            GameObject box = Instantiate(boxPrefab, firePoint.position, Quaternion.identity);
            Destroy(box, 0.3f); // Menghancurkan objek kotak setelah waktu tertentu
        }
    }
}
