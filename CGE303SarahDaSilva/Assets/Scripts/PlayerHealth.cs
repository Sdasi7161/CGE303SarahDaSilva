using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Variable to store the health of the player
    public int health = 100;

    //A reference to the health bar
    //This must be set in the inspector
    public DisplayBar healthBar;

    private Rigidbody2D rb;

    //Knockback force when player collides with enemy
    public float knockbackForce = 5f;

    //A prefab to spawn when the player dies
    //This must be set in the inspector
    public GameObject playerDeathEffect;

    //bool to keep track of if the player had been hit recently
    public static bool hitRecently;

    //Time in seconds to recover from hit
    public float hitRecoveryTime = 0.2f;

    private AudioSource playerAudio;
    public AudioClip playerHitSound;
   // public AudioClip playerDeathSound;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       //set the RigidBody2D reference
       rb = GetComponent<Rigidbody2D>();

        //Check if the Rigidbody2D reference is null
        if(rb == null)
        {
            //Log an error message if the rb is null
            Debug.LogError("Rigidbody2D not found on player");
        }

        //Set healthBar max value to the player's health
        healthBar.SetMaxValue(health);

        //initialize hitRecently to false
        hitRecently = false;

        //set the audiosource reference
        playerAudio = GetComponent<AudioSource>();

        animator = GetComponent<Animator>();
    }

    //A function to knock back the player when they collide with an enemy
    public void Knockback(Vector3 enemyPosition)
    {
        //If the player had been hit recently
        if (hitRecently)
        {
            //Return out of the function
            return;
        }

        //Set hitRecently to true
        hitRecently = true;

        if (gameObject.activeSelf)
        {
            //Start the coroutine to reset to hitRecently
            StartCoroutine(RecoverFromHit());
        }
        //Calculate the direction of the knockback
        Vector2 direction = transform.position - enemyPosition;

        //Normalize the direction vector
        //This gives a consistent knockback force regardless of the distance
        //Between the player and the enemy
        direction.Normalize();

        //Add upward direction to the knockback
        direction.y = direction.y * 0.5f + 0.5f;

        //Add force to the player in the direction of the knockback
        rb.AddForce(direction * knockbackForce, ForceMode2D.Impulse);

        //Coroutine to reset hitRecently after hitRecoveryTime seconds
        IEnumerator RecoverFromHit()
        {
            //Wait for hitRecoveryTime (0.2) seconds
            yield return new WaitForSeconds(hitRecoveryTime);

            //Set hitRecently to false
            hitRecently = false;

            //set the hit animation to false
            animator.SetBool("hit", false);
        }
    }

   public void TakeDamage(int damage)
    {
        //Subtract the damage from the health
        health -= damage;

        //Update the health bar
        healthBar.SetValue(health);

        //TODO: Play a sound effect when the player takes damage
        //TODO: Play an animation when the player takes damage

        //If the health bar is less than or equal to 0
        if (health <= 0)
        {
            //Call the die method
            Die();
        }
        else
        {
            //play the playerhitsound
            playerAudio.PlayOneShot(playerHitSound);

            //Play the player hit animation
            animator.SetBool("hit", true);
        }
    }

    //A function to die
    public void Die()
    {
        //Set gameover to true
        ScoreManagerScript.gameOver = true;

        //TODO: Play a sound effect when the player dies
        //TODO: Add the player death effect when the player dies

        //Instantiate the death effect at the player's position
        //GameObject deathEffect = Instantiate(playerDeathEffect, transform.position, Quanternion.identity);

        //Destroy the death effect after 2 seconds
        //Destroy(deathEffect, 2f);

       // playerAudio.PlayOneShot(playerDeathSound);

        GameObject deathEffect = Instantiate(playerDeathEffect, transform.position, Quaternion.identity);

        Destroy(deathEffect, 2f);

        // Disable the player object
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
