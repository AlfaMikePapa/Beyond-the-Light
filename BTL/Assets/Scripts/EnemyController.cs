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
        //pelaajan suunnasta liike
        Vector3 direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;

        //MoveBetweenPoints();
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer(movement);
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

    //Collision with player detection
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.name == "Player")
        {
            Debug.Log("EnemyHit");
        }
    }
}


