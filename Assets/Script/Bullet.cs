using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject boxPrefab; // Prefab objek kotak yang ingin ditampilkan
    public Transform firePoint;
    public float bulletSpeed = 15f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Tombol untuk menembak (misalnya Enter)
        {
            RenderBoxAtFirePoint(); // Panggil fungsi untuk merender kotak di tempat tembak
        }
    }

    void RenderBoxAtFirePoint()
    {
        GameObject box = Instantiate(boxPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = box.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.down * bulletSpeed;

        Destroy(box, 3f); // Menghancurkan objek kotak setelah waktu tertentu
    }
}
