using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishManager : MonoBehaviour
{
    private GameManager gameManager;

    private void Start()
    {
        // Temukan GameManager pada saat permainan dimulai
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            // Panggil metode PlayerCrossedFinishLine pada GameManager
            gameManager.PlayerCrossedFinishLine(other.gameObject);

            // Logika lain yang diinginkan ketika pemain mencapai finish line
            Debug.Log("Pemain mencapai finish line!");
        }
        else if (other.CompareTag("Enemy"))
        {
            // Panggil metode EnemyTouchesFinish pada GameManager
            gameManager.EnemyTouchesFinish();

            // Logika lain yang diinginkan ketika enemy menyentuh finish line
            Debug.Log("Enemy menyentuh finish line!");
        }
    }
}
