using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject CreditsPanel;

    public AudioSource audioSource;
    public AudioClip button;
    public AudioClip enter;

    void Start()
    {
        // Menutup panel saat game dimulai
        if (CreditsPanel != null)
        {
            CreditsPanel.SetActive(false);
        }
    }

    private void Update()
    {
        // Memainkan SFX setiap kali tombol keyboard ditekan
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            PlaySound(button);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            PlaySound(enter);
        }
    }

    // Fungsi untuk membuka atau menutup panel
    public void ShowCreditsPanel()
    {
        if (CreditsPanel != null)
        {
            CreditsPanel.SetActive(!CreditsPanel.activeSelf);
        }
    }

    // Fungsi untuk menutup panel
    public void CloseCreditPanel()
    {
        if (CreditsPanel != null && CreditsPanel.activeSelf)
        {
            CreditsPanel.SetActive(false);
        }
    }

    // Fungsi untuk memulai game
    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }

    // Fungsi untuk memainkan efek suara
    void PlaySound(AudioClip sound)
    {
        if (audioSource != null && sound != null)
        {
            audioSource.PlayOneShot(sound);
        }
    }
}