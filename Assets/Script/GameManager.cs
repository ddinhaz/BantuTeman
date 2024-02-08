using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOver;

    private Text GameOverText;

    public AudioSource SFXSource;
    public AudioClip ButtonSfx;

    private void Start()
    {
        // Pastikan panel win dan lose dimatikan pada awalnya
        GameOver.SetActive(false);

        // Dapatkan komponen Text pada panel win dan lose
        GameOverText = GameOver.GetComponentInChildren<Text>();
    }

    private void Update()
    {
        // Memainkan SFX setiap kali tombol keyboard ditekan
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            SFXSource.clip = ButtonSfx;
            SFXSource.Play();
        }
    }


    public void PlayerCrossedFinishLine(GameObject player)
    {
        // Tampilkan panel win dan atur teks (jika diperlukan)
        GameOver.SetActive(true);
        GameOverText.text = "Hoki Kamu Dek!"; // Atur teks sesuai kebutuhan

        // Lakukan tindakan lanjutan seperti menonaktifkan kontrol pemain atau menampilkan skor akhir
        // ...
    }

    public void EnemyTouchesFinish()
    {
        // Tampilkan panel lose dan atur teks (jika diperlukan)
        GameOver.SetActive(true);
        GameOverText.text = "Cupu Banget Dek!"; // Atur teks sesuai kebutuhan

        // Lakukan tindakan lanjutan seperti menonaktifkan kontrol pemain atau menampilkan pesan kekalahan
        // ...
    }

}
