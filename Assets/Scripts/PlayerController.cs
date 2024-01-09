using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed, jumpHeight;
    float velX, velY;
    Rigidbody2D rb;
    public Transform groundcheck;
    public bool isGrounded;
    public float groundCheckRadius;
    public LayerMask whatIsGround;  
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, whatIsGround);

        flipCharacter();


    }
    private void FixedUpdate()
    {
        Movement();
    }

    public void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }    

        
    }

    
        
    



    public void Movement()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;

        rb.velocity = new Vector2(velX * speed, velY);
    }

    public void flipCharacter()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
