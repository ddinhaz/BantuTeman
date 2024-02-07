using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerak : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D rb;
    private float dirX = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(dirX * MoveSpeed, rb.velocity.y);
    }
}