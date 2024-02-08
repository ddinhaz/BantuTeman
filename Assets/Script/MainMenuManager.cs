using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button blinkingButton;
    private bool isBlinking = false;

    void Start()
    {
        // Mulai fungsi kedipan
        StartBlinking();
    }

    void StartBlinking()
    {
        isBlinking = true;
        StartCoroutine(Blink());
    }

    void StopBlinking()
    {
        isBlinking = false;
    }

    IEnumerator Blink()
    {
        while (isBlinking)
        {
            blinkingButton.interactable = !blinkingButton.interactable; // Toggle keadaan tombol

            yield return new WaitForSeconds(0.5f); // Tunggu 0.5 detik
        }
    }

    // Panggil fungsi ini dari tombol atau event lainnya untuk mengaktifkan atau menonaktifkan kedipan
    public void ToggleBlinking()
    {
        if (isBlinking)
        {
            StopBlinking();
        }
        else
        {
            StartBlinking();
        }
    }
}
