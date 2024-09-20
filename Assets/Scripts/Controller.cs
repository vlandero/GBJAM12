using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float movementSpeed;

    protected float speedX, speedY;

    protected Rigidbody2D rb;
    public Animator _animator;

    GameManager gameManager;
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    protected void Move()
    {
        speedX = Input.GetAxisRaw("Horizontal") * movementSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movementSpeed;
        if(_animator != null && 
            (speedX > 0.1f || 
             speedX < -0.1f || 
             speedY > 0.1f ||
             speedY < -0.1f))
        {
            _animator.SetFloat("X", speedX);
            _animator.SetFloat("Y", speedY);
        }
        rb.velocity = new Vector2(speedX, speedY);

    }
}
