using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{
    //Player Movement speed
    public float moveSpeed = 5f;        //Player movement speed
    public float jumpForce = 10f;             //Force applied when jumping
    public LayerMask groundLayer;      //Layer mask for detecting ground
    public Transform groundCheck;       //Transform representing the position to check the ground
    public float groundCheckRadius = 0.2f;  //Radius for ground check

    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;

    //An audio clip to hold jump sound
    public AudioClip jumpSound;

    //An audio source to play our sounds
    private AudioSource playerAudio;

    //TriggerZone audio source
    public AudioSource triggerSound;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
       //Get the Rigidbody2D component attached to the GameObject
       rb = GetComponent<Rigidbody2D>();

       playerAudio = GetComponent<AudioSource>(); 

        animator = GetComponent<Animator>();
 

        //Ensure the groundCheck variable is assigned
        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to player controller!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Get input values for horizontal movement
        horizontalInput = Input.GetAxis("Horizontal");

        //Check for jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //Apply an upwards for jumping
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            //Play jump sound effect
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    void FixedUpdate()
    {
        //Move the player using Rigidbody2D in FixedUpdate
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        //Set animator parameter xVelocityAbs to absolute value of x velocity
        animator.SetFloat("xVelocityAbs", Mathf.Abs(rb.velocity.x));

        //set animator parameter yVelocity to y velocity
        animator.SetFloat("yVelocity", rb.velocity.y);

        //Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        //set animator parameter onGround to isGrounded
        animator.SetBool("onGround", isGrounded);

        //Optionally, you can add animations or other behavior here based on player state

        //Ensure the player is facing the direct movement
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f); // Facing right
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f); // Facing left
        } 
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CollisionTag")
        {
            triggerSound.Play();
        }
    }




}
