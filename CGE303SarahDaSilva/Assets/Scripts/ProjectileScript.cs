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
