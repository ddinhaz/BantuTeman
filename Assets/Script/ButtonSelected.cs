using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonSelected : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public TMP_Text button1Text;
    public TMP_Text button2Text;
    public float blinkInterval = 0.5f;

    private bool isBlinking = false;
    private Button selectedButton;

    void Start()
    {
        // Auto select button pertama saat game dimulai
        SelectButton(button1);

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
        // Pastikan teks tombol yang sedang terseleksi tetap terlihat
        if (selectedButton != null && selectedButton.GetComponentInChildren<TMP_Text>() != null)
        {
            selectedButton.GetComponentInChildren<TMP_Text>().enabled = true;
        }
    }

    IEnumerator Blink()
    {
        while (isBlinking)
        {
            // Toggle keadaan teks tombol yang sedang terseleksi
            if (selectedButton != null && selectedButton.GetComponentInChildren<TMP_Text>() != null)
            {
                selectedButton.GetComponentInChildren<TMP_Text>().enabled = !selectedButton.GetComponentInChildren<TMP_Text>().enabled;
            }

            yield return new WaitForSeconds(blinkInterval); // Tunggu interval kedipan
        }
    }

    // Fungsi ini dipanggil ketika tombol dipilih
    public void OnButtonSelected(Button selected)
    {
        // Menetapkan tombol yang sedang terseleksi
        selectedButton = selected;

        // Memulai kedipan ulang untuk tombol yang baru terseleksi
        StopBlinking();
        StartBlinking();
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

    // Fungsi ini dapat dipanggil dari luar untuk menghentikan kedipan
    public void StopBlinkingExternal()
    {
        StopBlinking();
    }

    // Fungsi ini dipanggil ketika tombol pertama dipilih
    public void SelectButton1()
    {
        SelectButton(button1);
    }

    // Fungsi ini dipanggil ketika tombol kedua dipilih
    public void SelectButton2()
    {
        SelectButton(button2);
    }

    // Fungsi untuk memilih tombol secara programatik
    private void SelectButton(Button button)
    {
        if (button != null)
        {
            button.Select();
            OnButtonSelected(button);
        }
    }

    // Fungsi untuk dipanggil saat panel baru dibuka untuk memilih tombol secara otomatis
    public void OpenPanel()
    {
        // Pilih tombol pertama saat panel dibuka
        SelectButton1();
    }
}
