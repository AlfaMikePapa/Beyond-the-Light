using UnityEngine.Experimental.Rendering.LWRP;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    UnityEngine.Experimental.Rendering.Universal.Light2D myLight;

    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D playerRb;
    private SpriteRenderer sprRend;

    private bool playerOnGround;
    public Transform groundCheck;
    public LayerMask groundLayerMask;

    private bool playerOnWater;
    public Transform waterCheck;
    public LayerMask waterLayerMask;

    private float groundCheckRadius = .1f;
    private bool canDoubleJump;

    private Animator anim;

    public Canvas bgcanvas;
    public Image srImage;

    //Attacking variables
    public float attackCooldownTime, attackCooldown;

    //Knockback variables
    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        sprRend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        myLight = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();

        attackCooldown = attackCooldownTime;
    }


    void Update()
    {
        if (knockBackCounter <= 0)
        {
            movePlayer();
            CheckGround();
            Jump();

            //if player is on the ground -> reset double jump
            if (playerOnGround)
            {
                canDoubleJump = true;
            }

            //attacking
            if (Input.GetButtonDown("Fire1") && attackCooldown <= 0)
            {
                Attack();
                attackCooldown = attackCooldownTime;
            }
        } else
        {
            knockBackCounter -= Time.deltaTime;
        }

        // if player is on water gravity will be -0.03
        if (playerOnWater == true)
        {
            playerRb.gravityScale = -0.03f;
            Debug.Log("Ollaa vittu märkiä");
        }
        else
        {
            playerRb.gravityScale = 5f;
            Debug.Log("Nyt ollaa kuivia");
        }
           
        //count down the attack cooldown
        attackCooldown -= Time.deltaTime;


        //set the variables used in the animator to the same variables in this script 
        anim.SetBool("playerOnGround", playerOnGround);
        anim.SetFloat("moveSpeed", Mathf.Abs(playerRb.velocity.x)); // <- take the absolute value of the velocity -> player animates while moving on a negative axis

        //Reduce light to 0.2f when player is below -25
        if (playerRb.transform.position.y < -35)
        {
            myLight.intensity = 0.8f;
        }
        else
        {
            myLight.intensity = 0.0f;
        }


    }

    //Player movement
    void movePlayer()
    {
        playerRb.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"), playerRb.velocity.y);

        //flip the sprite based on which way the player is moving
        if (playerRb.velocity.x < 0)
        {
            //sprRend.flipX = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (playerRb.velocity.x > 0)
        {
            //sprRend.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
   
    //Check if the player is on the water
    void CheckWater()
    {
        playerOnWater = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, waterLayerMask);
        Debug.Log("VERES");
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
        }
        else
        {
            //double jumping
            if (Input.GetButtonDown("Jump") && canDoubleJump)
            {
                playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
                canDoubleJump = false;
            }
        }
    }

    void Attack()
    {
        anim.SetTrigger("attack");
    }

 
    public void KnockBack()
    {
        knockBackCounter = knockBackLength;
        playerRb.velocity = new Vector2(0f, knockBackForce);
    }

}
