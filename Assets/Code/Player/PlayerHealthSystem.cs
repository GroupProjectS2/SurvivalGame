using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{

    int playerMaxHealth = 100;
    int playerCurrentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        healthBar.SetHealth(playerMaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCurrentHealth > playerMaxHealth)
        {
            playerCurrentHealth = playerMaxHealth;
        }

        if(playerCurrentHealth < 0)
        {
            playerCurrentHealth = 0;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            playerCurrentHealth = playerMaxHealth;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(1);
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(5);
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(10);
        }

    }

    //called when player takes damage
    void TakeDamage(int damage)
    {
        playerCurrentHealth -= damage;

        healthBar.SetHealth(playerCurrentHealth);
    }
}
