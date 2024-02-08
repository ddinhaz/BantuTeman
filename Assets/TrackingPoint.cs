using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingPoint : MonoBehaviour
{
    public float MoveSpeed = 3f;
    private float minX, maxX;
    private bool movingRight = true;
    private float initialCameraX;

    void Start()
    {
        // Mendapatkan lebar layar dalam satuan koordinat dunia
        float screenWidthInWorldUnits = Camera.main.orthographicSize * 2 * Camera.main.aspect;
        
        // Menghitung batas minimal dan maksimal pergerakan
        minX = -screenWidthInWorldUnits / 2;
        maxX = screenWidthInWorldUnits / 2;

        // Mendapatkan posisi awal kamera pada sumbu X
        initialCameraX = Camera.main.transform.position.x;
    }

    void Update()
    {
        // Mengambil posisi objek saat ini
        Vector3 currentPosition = transform.position;

        // Mendapatkan pergeseran kamera pada sumbu X
        float cameraShiftX = Camera.main.transform.position.x - initialCameraX;

        // Menggerakkan objek ke kanan atau kiri dengan kecepatan yang ditentukan
        if (movingRight)
        {
            currentPosition.x += (MoveSpeed + cameraShiftX) * Time.deltaTime;
        }
        else
        {
            currentPosition.x -= (MoveSpeed + cameraShiftX) * Time.deltaTime;
        }

        // Memastikan objek tetap dalam batasan pergerakan
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX);

        // Mengatur posisi objek yang telah di-update
        transform.position = currentPosition;

        // Membalik arah pergerakan jika objek mencapai batas kiri atau kanan
        if (currentPosition.x >= maxX || currentPosition.x <= minX)
        {
            movingRight = !movingRight;
        }
    }
}
