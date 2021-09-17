using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpHeight = 13f;

    Rigidbody2D rigidBody;
    Animator animator;
    Collider2D collider2D;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
    }

    void Update()
    {
        Run();
        Jump();
        FlipSprite();
    }

    void Run()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        rigidBody.velocity = new Vector2(horizontalMovement * runSpeed, rigidBody.velocity.y);

        bool playerIsMovingHorizontally = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", playerIsMovingHorizontally);
    }

    void Jump()
    {
        if (!collider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            return;
        
        if (Input.GetButtonDown("Jump"))
            rigidBody.velocity = new Vector2(0f, jumpHeight);
    }

    void FlipSprite()
    {
        bool playerIsMovingHorizontally = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;

        if (playerIsMovingHorizontally)
            transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
    }
}
