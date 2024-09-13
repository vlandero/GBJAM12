using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float movementSpeed;

    protected float speedX, speedY;

    protected Rigidbody2D rb;

    GameManager gameManager;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Move()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movementSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movementSpeed;
        rb.velocity = new Vector2(speedX, speedY);
    }
}
