using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOver;

    private Text GameOverText;

    public Bullet bulletScript; // Referensi ke skrip Bullet
    public Text cooldownText; // Referensi ke teks cooldown di Canvas
    public float cooldownTime = 4f; // Waktu cooldown dalam detik

    private float cooldownTimer; // Timer cooldown

    public SkillMovement skillMovement; // Referensi ke skrip SkillMovement
    public AudioSource audioSource; // Komponen AudioSource
    public AudioClip jump; // Suara untuk loncat
    public AudioClip winnersfx; // Suara untuk game over
    public AudioClip losesfx; // Suara untuk game over

    private void Start()
    {
        // Pastikan panel win dan lose dimatikan pada awalnya
        GameOver.SetActive(false);

        // Dapatkan komponen Text pada panel win dan lose
        GameOverText = GameOver.GetComponentInChildren<Text>();

        cooldownTimer = 0f; // Set timer awal ke 0

        // Mendapatkan komponen AudioSource jika belum ada
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Pastikan audioSource tidak mengisi loop (opsional)
        audioSource.loop = false;
    }

    void Update()
    {
        // Update timer cooldown dan tampilkan teks countdown
        UpdateCooldownTimer();

        // Munculkan teks countdown mundur
        cooldownText.text = Mathf.Ceil(cooldownTimer).ToString();

        // Jika cooldown selesai, munculkan teks untuk menembak
        if (cooldownTimer <= 0f)
        {
            cooldownText.text = "0";
        }

        // Mengecek apakah tombol Enter ditekan dan cooldown sudah selesai
        if (Input.GetKeyDown(KeyCode.Return) && cooldownTimer <= 0f)
        {
            bulletScript.RenderBoxAtFirePoint(); // Panggil fungsi untuk menembak dari skrip Bullet
            cooldownTimer = cooldownTime; // Mulai cooldown baru
        }

        // Mengecek apakah tombol Space ditekan dan SkillMovement dapat meloncat
        if (Input.GetKeyDown(KeyCode.Space) && skillMovement != null && skillMovement.canJump)  
        {
            // Memanggil fungsi untuk memainkan suara loncat
            PlayJumpSound();
        }
    }


    public void PlayerCrossedFinishLine(GameObject player)
    {
        Time.timeScale = 0;
        // Tampilkan panel win dan atur teks (jika diperlukan)
        GameOver.SetActive(true);
        GameOverText.text = "Hoki Kamu Dek!"; // Atur teks sesuai kebutuhan
        audioSource.Stop();
        audioSource.PlayOneShot(winnersfx);

        // Lakukan tindakan lanjutan seperti menonaktifkan kontrol pemain atau menampilkan skor akhir
        // ...
    }

    public void EnemyTouchesFinish()
    {
        // Pause permainan
        Time.timeScale = 0;
        // Tampilkan panel lose dan atur teks (jika diperlukan)
        GameOver.SetActive(true);
        GameOverText.text = "Cupu Banget Dek!"; // Atur teks sesuai kebutuhan
        audioSource.Stop();
        audioSource.PlayOneShot(losesfx);

        // Lakukan tindakan lanjutan seperti menonaktifkan kontrol pemain atau menampilkan pesan kekalahan
        // ...
    }

    // Fungsi untuk me-restart permainan dengan memuat kembali scene saat ini
    public void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        // Resume permainan
        Time.timeScale = 1;
    }
    
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

     void UpdateCooldownTimer()
    {
        // Mengurangi waktu cooldown setiap frame
        cooldownTimer -= Time.deltaTime;

        // Memastikan waktu cooldown tidak menjadi nilai negatif
        cooldownTimer = Mathf.Max(0f, cooldownTimer);
    }

    void PlayJumpSound()
    {
        // Memastikan jumpSound telah diisi
        if (jump != null && audioSource != null)
        {
            // Memainkan suara loncat
            audioSource.PlayOneShot(jump);
        }
    }
}
