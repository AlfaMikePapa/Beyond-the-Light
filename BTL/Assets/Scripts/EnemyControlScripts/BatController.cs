﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatController : MonoBehaviour
{
    //Moving enemy variables
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private Rigidbody2D enemyRB;
    private bool movingRight;
    public GameObject Player;
    public Transform player;
    private Vector2 movement;
    public float distance;

    //To flip the sprite
    public Rigidbody2D enemyRb;
    public SpriteRenderer sprRend;


    //Hitting player variables
    public float hitTimer = 0.2f;
    public bool timerIsRunning = false;

    //Hitting enemy variables
    public float enemyCurrentHealth;
    public float enemyMaxHealth = 3;
    public float nextHitTime = 1; //cooldown between hits
    public float damage = 1; //hit damage
    private float nextHit;

    //Animator batAC;


    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();

        //unparent the checkpoints so that they don't move with the enemy
        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        enemyCurrentHealth = enemyMaxHealth; //set enemy health
        nextHit = Time.time; //for hit cooldown

        //batAC = GetComponent<Animator>(); //Animator controller of Hog
    }

    void Update()
    {
        HitEnemy();
        //players position  into movement
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;

        //Calculate distance to player
        distance = Vector3.Distance(player.position, transform.position);

        if (distance < 0.5)
        {
            timerIsRunning = true;

            if (hitTimer > 0)
            {
                hitTimer -= Time.deltaTime;
            }
            else
            {
                PlayerHealthController.instance.DealDamage(1);
                timerIsRunning = false;
            }
        }
        else
        {
            hitTimer = 0.2f;
        }
    }

    private void FixedUpdate()
    {
        //Increased movement speed when player is close and follow
        if (distance < 3.5 && enemyRB.position.x > leftPoint.position.x && enemyRB.position.x < rightPoint.position.x) //Only follow between points
        {
            //batAC.SetFloat("Speed", 0.8f);
            moveSpeed = 0.0f;
            MoveTowardsPlayer(movement);

            if (enemyRb.position.x > player.position.x) //Flip sprite according to player if in attack range
            {
                sprRend.flipX = false;
            }
            else
            {
                sprRend.flipX = true;
            }
        }
        else
        {
            //batAC.SetFloat("Speed", 0.2f);
            moveSpeed = 0.0f;
            MoveBetweenPoints();

            if (enemyRb.velocity.x < 0) //Flip sprite according to points if not in attack range
            {
                sprRend.flipX = false;
            }
            if (enemyRb.velocity.x > 0)
            {
                sprRend.flipX = true;
            }

        }
    }

    void MoveTowardsPlayer(Vector2 direction)
    {
        enemyRB.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public void MoveBetweenPoints()
    {
        if (movingRight)
        {
            enemyRB.velocity = new Vector2(moveSpeed, enemyRB.velocity.y);

            if (transform.position.x > rightPoint.position.x)
            {
                movingRight = false;
            }
        }
        else
        {
            enemyRB.velocity = new Vector2(-moveSpeed, enemyRB.velocity.y);

            if (transform.position.x < leftPoint.position.x)
            {
                movingRight = true;
            }
        }
    }

    void HitEnemy()
    {
        //Damage enemy if player is close and hits
        if (Input.GetButtonDown("Fire1") && distance < 1 && nextHit <= Time.time)
        {
            //Reduce enemy health
            enemyCurrentHealth -= damage;

            //Hit cooldown
            nextHit = Time.time + nextHitTime;
        }

        //Disable enemy when health runs out
        if (enemyCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
