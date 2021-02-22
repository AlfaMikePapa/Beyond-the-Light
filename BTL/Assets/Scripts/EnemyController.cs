using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    private Rigidbody2D enemyRB;
    private bool movingRight;
    public GameObject Player;
    
    public Transform player;
    private Vector2 movement;
    public float distance;
    
    public float hitTimer = 0.2f;
    public bool timerIsRunning = false;

    
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();

        //unparent the checkpoints so that they don't move with the enemy
        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;
    }

    void Update()
    {
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
                Debug.Log("PlayerHitByEnemy");
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
        if (distance < 3.5)
        {
            moveSpeed = 4;
            MoveTowardsPlayer(movement);
        }
        else
        {
            moveSpeed = 1.5f;
            MoveBetweenPoints();
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
}


