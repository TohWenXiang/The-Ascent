using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D thePlayerRB;

    //input
    private float horizontalInput;
    private bool isJumping;
    private bool isGrounded;

    //movement
    public float accelerationMagnitude;
    public float maxSpeed;

    public float decelerationMagnitude;
    
    

    private void Awake()
    {
        thePlayerRB = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        isJumping = Input.GetButtonDown("Jump");
        Debug.Log(thePlayerRB.velocity);
    }

    private void FixedUpdate()
    {
        //horizontal movement
        Moving();
        Jumping();
    }

    private void Moving()
    {
        float acceleration;
        float deceleration;
        float velocity;

        //get initial velocity;
        velocity = thePlayerRB.velocity.x;

        //calculate acceleration
        acceleration = accelerationMagnitude * horizontalInput;

        deceleration = 0;

        //calculate deceleration
        if (velocity > 0)
        {
            if (horizontalInput < 0)
            {
                //if i'm moving right and i want to decelerate

                deceleration = decelerationMagnitude * horizontalInput;
            }
        }

        velocity = thePlayerRB.velocity.x + (acceleration * Time.fixedDeltaTime) + (deceleration * Time.deltaTime) ;


        //cap velocity
        velocity = Mathf.Clamp(velocity, -maxSpeed, maxSpeed);

        thePlayerRB.velocity = new Vector2(velocity, thePlayerRB.velocity.y);
    }

    private void Jumping()
    {
        
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
