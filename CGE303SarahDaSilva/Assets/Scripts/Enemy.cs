using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //The enemy's health
    public int health = 100;

    //A prefab to spawn when the enemy dies
    public GameObject deathEffect;

    //A refernce to the health bar
    private DisplayBar healthBar;

    private void Start()
    {
        //Find the health bar in the children of the Enemy
        healthBar = GetComponentInChildren<DisplayBar>();

        if (healthBar == null)
        {
            //If the health bar is not found, log an error
            Debug.LogError("HealthBar (DisplayBar script) not found");
            return;
        }
        //Set the max value of the health bar to the enemy's health
        healthBar.SetMaxValue(health);
    }
    public void TakeDamage(int damage)
    {
        //Subtract the damage dealth from the health
        health -= damage;

        //Update the health bar
        healthBar.SetValue(health);

        //If health is less than or equal to 0
        if(health <= 0)
        {
            //Call the Die dunction
            Die();
        }
    }

    void Die()
    {
        //Spawn a death effect
        Instantiate(deathEffect, transform.position, Quaternion.identity);

        //Destroy the enemy
        Destroy(gameObject);
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
