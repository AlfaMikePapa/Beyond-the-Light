using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    //used so that we can use DealDamage() function in other scripts
    public static PlayerHealthController instance;

    public int playerCurrentHealth, playerMaxHealth;

    public float invincibilityLength;
    private float invincibilityCounter;

    private SpriteRenderer sprRend;



    //as soon as the game starts, set instance to this
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //Set players health to max at the start of the game/level
        playerCurrentHealth = playerMaxHealth;

        sprRend = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;

            if(invincibilityCounter <= 0)
            {
                //set the players alpha back to normal
                sprRend.color = new Color(sprRend.color.r, sprRend.color.g, sprRend.color.b, 1f);
            }
        }
    }

    //Function that deals given damage, can be called from other scripts
    public void DealDamage(int damage)
    {
        if(invincibilityCounter <= 0)
        {

            playerCurrentHealth -= damage;

            //disable the player if health is 0 or less
            if (playerCurrentHealth <= 0)
            {
                playerCurrentHealth = 0;

                gameObject.SetActive(false);

                //restart the current level
                LevelManager.instance.RestartLevel();
            }
            else
            {
                //knockback the player
                PlayerController.instance.KnockBack();

                //reset the invincibility counter
                invincibilityCounter = invincibilityLength;

                //set the players alpha to half
                sprRend.color = new Color(sprRend.color.r, sprRend.color.g, sprRend.color.b, .5f);
            }

            UIController.instance.UpdateHealthUI();
        }
    }
}