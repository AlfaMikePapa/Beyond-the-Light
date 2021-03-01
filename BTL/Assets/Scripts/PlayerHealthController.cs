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



    //as soon as the game starts, set instance to this
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //Set players health to max at the start of the game/level
        playerCurrentHealth = playerMaxHealth;
    }

    void Update()
    {
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
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
            }
            else
            {
                //reset the invincibility counter
                invincibilityCounter = invincibilityLength;
            }

            UIController.instance.UpdateHealthUI();
        }
    }
}