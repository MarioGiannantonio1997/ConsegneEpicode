using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] public int playerNumber = 1;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

        void Update()
    {
        // ✅ Input dinamico basato sul player number
        string horizontalInput = "P" + playerNumber + "Horizontal";
        string jumpInput = "P" + playerNumber + "Jump";

        // ✅ Movimento orizzontale
        float movX = Input.GetAxisRaw(horizontalInput);
        rb.velocity = new Vector2(movX * moveSpeed, rb.velocity.y);

        // ✅ Salto
        if (Input.GetButtonDown(jumpInput) && !isJumping)
        {
            Debug.Log($"Player {playerNumber} is jumping");
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // ✅ Reimposta salto quando tocca terra
        isJumping = false;
    }
}
