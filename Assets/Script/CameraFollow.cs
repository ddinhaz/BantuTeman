using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    private float initialY;

    void Start()
    {
        // Simpan posisi Y awal kamera
        initialY = transform.position.y;
    }

    private void Update()
    {
        if (player != null)
        {
            // Mengatur posisi kamera ke posisi pemain dengan offset ke sisi kiri layar
            float targetX = player.position.x + offset.x;
            float cameraX = transform.position.x;

            // Jika pemain bergerak ke arah kanan, kamera akan mengikuti pemain
            if (targetX > cameraX)
            {
                transform.position = new Vector3(targetX, initialY, transform.position.z);
            }
        }
    }
}
