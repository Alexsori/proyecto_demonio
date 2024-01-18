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
    Animator anim;
    public GameObject Weapon;
    public float tiempoDeActivacion = 1f;
    public AudioSource audioSource;
    public AudioClip Golpe;
    public AudioClip Salto;
    private bool isAttacking = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, whatIsGround);

        if(isGrounded)
        {
            anim.SetBool("Jump", false);
        }
        else
        {
            anim.SetBool("Jump", true);
        }



        flipCharacter();
        Attack();

    }
    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

    public void Attack()
    {
 

        if (Input.GetButtonDown("Fire1"))
        {
            isAttacking = true;
            anim.SetTrigger("Attack1");

        }


    }

    public void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            audioSource.PlayOneShot(Salto);
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }    

        
    }

    
        
    



    public void Movement()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;

        rb.velocity = new Vector2(velX * speed, velY);

        if(rb.velocity.x != 0)
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }
    }

    public void flipCharacter()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(2.54779f, 2.402077f, 0);
        }
        else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-2.54779f, 2.402077f, 0);
        }
    }

    public void PlayAttackSound()
    {
        audioSource.PlayOneShot(Golpe);
    }

    public void FinishAttack()
    {
        isAttacking = false;
    }

}
