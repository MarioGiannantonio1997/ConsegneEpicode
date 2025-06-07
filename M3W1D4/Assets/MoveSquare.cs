using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSquare : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private float maxDistance = 10f;

    private Vector2 initialPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = rb.position;
    }

    void Update()
    {
        PlayerMovementUpdate();
        if (Vector2.Distance(rb.position, initialPosition) > maxDistance)
        {
            rb.position = initialPosition;
        }
    }
    void PlayerMovementUpdate()
    {
        float movX = Input.GetAxisRaw("Horizontal");
        float movY = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(movX, movY).normalized * moveSpeed;
    }
}
