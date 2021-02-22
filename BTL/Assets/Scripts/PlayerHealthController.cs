using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    //used so that we can use DealDamage() function in other scripts
    public static PlayerHealthController instance;

    public int playerCurrentHealth;
    public int playerMaxHealth;

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

    }

    //Function that deals given damage, can be called from other scripts
    public void DealDamage(int damage)
    {
        playerCurrentHealth -= damage;

        //disable the player if health is 0 or less
        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }

        UIController.instance.UpdateHealthUI();
    }
}