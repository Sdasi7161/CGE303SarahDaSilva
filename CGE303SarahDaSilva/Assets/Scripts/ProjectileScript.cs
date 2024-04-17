using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Projectile class that controls the movement of the projectile
//Attach this script to the projectile prefab

public class ProjectileScript : MonoBehaviour
{
    // Start is called before the first frame update

    //Rigidbody component of the projectile
    private Rigidbody2D rb;

    // Speed of the projectile with a default value of 20
    public float speed = 20f;

    //Damage of the projectile with a default value 20
    public int damage = 20;

    //Impact effect of the projectile
    public GameObject impactEffect; 

    //Function called when the projectile collides with another object
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        //Get the Enemy component of the object that was hit
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        //If the object that was hit has an Enemy component
        if(enemy != null)
        {
            //Call the TakeDamage function of the Enemy component
            enemy.TakeDamage(damage);
        }

        //If the object that was hit is not the player
        if(hitInfo.gameObject.tag != "Player")
        {
            //Instantionte the impact effect
            Instantiate(impactEffect, transform.position, Quaternion.identity);
            //Destroy the projectile
            Destroy(gameObject);
        }
    }
    //Start is called before the first frame update
    void Start()
    {
        //get the rigidbody component
        rb = GetComponent<Rigidbody2D>();

        //Set the velocity of the projectile to fire to the right at the speed
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
