﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D playerRb;
    private SpriteRenderer sprRend;

    private bool playerOnGround;
    public Transform groundCheck;
    public LayerMask groundLayerMask;

    private float groundCheckRadius = .2f;
    private bool canDoubleJump;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        sprRend = GetComponent<SpriteRenderer>();
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
