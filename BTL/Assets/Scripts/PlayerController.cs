using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D playerRb;
    private SpriteRenderer sprRend;

    private bool playerOnGround;
    public Transform groundCheck;
    public LayerMask groundLayerMask;

    private float groundCheckRadius = .1f;
    private bool canDoubleJump;

    private Animator anim;

    public Canvas bgcanvas;
    public Image srImage;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        sprRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        movePlayer();
        CheckGround();
        Jump();


        //if player is on the ground -> reset double jump
        if (playerOnGround)
        {
            canDoubleJump = true;
        }

        //set the variables used in the animator to the same variables in this script 
        anim.SetBool("playerOnGround", playerOnGround);
        anim.SetFloat("moveSpeed", Mathf.Abs(playerRb.velocity.x)); // <- take the absolute value of the velocity -> player animates while moving on a negative axis
    }

    //Player movement
    void movePlayer()
    {
        playerRb.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), playerRb.velocity.y);

        //flip the sprite based on which way the player is moving
        if (playerRb.velocity.x < 0)
        {
            sprRend.flipX = true;
        }
        else if (playerRb.velocity.x > 0)
        {
            sprRend.flipX = false;
        }
    }

    //Check if the player is on the ground
    void CheckGround()
    {
        playerOnGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayerMask);
    }

    //Jumping
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && playerOnGround)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        } else
        {
            //double jumping
            if(Input.GetButtonDown("Jump") && canDoubleJump)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
                canDoubleJump = false;
            }
        }
    }


}
