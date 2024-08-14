using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierRandomMovemoment : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetRandomDirection();
    }

    void FixedUpdate()
    {
        Move();
    }

    void SetRandomDirection()
    {
        float angle = Random.Range(0f, 2f * Mathf.PI);
        movement = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }

    void Move()
    {
        rb.velocity = movement * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Barrier"))
        {
            ContactPoint2D contact = collision.contacts[0];
            Vector2 reflectDir = Vector2.Reflect(movement, contact.normal);
            movement = reflectDir.normalized;
        }
    }
}
