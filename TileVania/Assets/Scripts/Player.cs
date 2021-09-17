using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;
    [SerializeField] float jumpHeight = 13f;

    Rigidbody2D myRigidBody2D;
    Animator myAnimator;
    Collider2D myCollider2D;
    float gravityScaleAtStart;
    
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider2D = GetComponent<Collider2D>();

        gravityScaleAtStart = myRigidBody2D.gravityScale;
    }

    void Update()
    {
        Run();
        Jump();
        Climb();
        FlipSprite();
    }

    void Run()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        myRigidBody2D.velocity = new Vector2(horizontalMovement * runSpeed, myRigidBody2D.velocity.y);

        bool playerIsMovingHorizontally = Mathf.Abs(myRigidBody2D.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerIsMovingHorizontally);
    }

    void Jump()
    {
        if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
            return;
        
        if (Input.GetButtonDown("Jump"))
            myRigidBody2D.velocity = new Vector2(0f, jumpHeight);
    }

    void Climb()
    {
        if (!myCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myAnimator.SetBool("isClimbing", false);
            myAnimator.SetBool("isClimbingIdle", false);
            myRigidBody2D.gravityScale = gravityScaleAtStart;
            return;
        }

        float verticalMovement = Input.GetAxis("Vertical");
        myAnimator.SetBool("isClimbing", true);
        myRigidBody2D.velocity = new Vector2(myRigidBody2D.velocity.x, verticalMovement * climbSpeed);
        myRigidBody2D.gravityScale = 0f;

        //bool playerIsMovingVertically = Mathf.Abs(myRigidBody2D.velocity.y) > Mathf.Epsilon;
        //myAnimator.SetBool("isClimbing", playerIsMovingVertically);

        if (myRigidBody2D.gravityScale == 0 && verticalMovement == 0)
            myAnimator.SetBool("isClimbingIdle", true);

        if (myRigidBody2D.gravityScale == 0 && verticalMovement != 0)
            myAnimator.SetBool("isClimbingIdle", false);
    }

    void FlipSprite()
    {
        bool playerIsMovingHorizontally = Mathf.Abs(myRigidBody2D.velocity.x) > Mathf.Epsilon;

        if (playerIsMovingHorizontally)
            transform.localScale = new Vector2(Mathf.Sign(myRigidBody2D.velocity.x), 1f);
    }
}