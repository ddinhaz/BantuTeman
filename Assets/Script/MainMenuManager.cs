using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public GameObject CreditsPanel;

    void Start()
    {
        // Menutup panel saat game dimulai
        if (CreditsPanel != null)
        {
            CreditsPanel.SetActive(false);
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
    }
}