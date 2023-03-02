using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement variables
    public float speed = 5f;
    public Vector2 moveDirection;

    // Jump variables
    private Rigidbody2D rigidBody2D;
    private bool isGrounded, isOnPlatform;
    public LayerMask groundLayer, platformLayer;
    public Transform groundCheck;
    private float jumpHeight = 15f;
    public float acceleration = .75f, deceleration = 1f;

    // Start
    private void Start()
    {
        rigidBody2D= GetComponent<Rigidbody2D>();
        groundCheck= GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        if (Input.GetAxis("Horizontal") != 0)
        {
            moveDirection = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
            rigidBody2D.velocity = new Vector2(speed * Input.GetAxisRaw("Horizontal"), rigidBody2D.velocity.y);
        }

        // Jump
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, .5f, groundLayer);
        isOnPlatform = Physics2D.OverlapCircle(groundCheck.position, .5f, platformLayer);

        if (Input.GetKeyDown("w") || Input.GetKeyDown("space") || Input.GetKeyDown("up"))
        {
            if (isGrounded || isOnPlatform)
            {
                rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, jumpHeight);
                isGrounded = false;
            }
        }

        // Movement in platforms
        // Jump to platform, first we check if we are jumping and we change the Layer so we can go over the platform, this is done in the collision of the layers
        if (rigidBody2D.velocity.y > 0)
        {
            gameObject.layer = 7;
        }
        else
        {
            gameObject.layer = 0;
        }
    }

    // Handle getting of the platform
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            if (Input.GetKey("down") || Input.GetKey("s"))
            {
                Collider2D collider= collision.collider;
                collider.isTrigger = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            collision.isTrigger = false;
        }
    }
}