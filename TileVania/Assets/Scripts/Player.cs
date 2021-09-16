using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpHeight = 5f;

    Rigidbody2D rigidBody;
    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Run();
        FlipSprite();

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    void Run()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        rigidBody.velocity = new Vector2(horizontalMovement * runSpeed, rigidBody.velocity.y);
    }

    void Jump()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpHeight);
    }

    void FlipSprite()
    {
        bool ifPlayerIsMovingHorizontally = Mathf.Abs(rigidBody.velocity.x) > Mathf.Epsilon;

        if (ifPlayerIsMovingHorizontally)
            transform.localScale = new Vector2(Mathf.Sign(rigidBody.velocity.x), 1f);
    }
}
