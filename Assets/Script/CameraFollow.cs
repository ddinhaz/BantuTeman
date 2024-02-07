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
            // Mengatur posisi kamera ke posisi pemain dengan offset
            transform.position = new Vector3(player.position.x + offset.x, initialY, transform.position.z);
        }
    }
}
