using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //The enemy's health
    public int health = 100;

    //A prefab to spawn when the enemy dies
    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        //Subtract the damage dealth from the health
        health -= damage;

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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
