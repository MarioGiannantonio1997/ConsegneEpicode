using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

    private bool isJumping = false;

    private Vector2 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        PlayerMovementUpdate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jumping");
            PlayerJumping();
        }
    }
    void PlayerMovementUpdate()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(movX * moveSpeed, rb.velocity.y);
    }

    void PlayerJumping()
    {
        isJumping = true;
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }
}
