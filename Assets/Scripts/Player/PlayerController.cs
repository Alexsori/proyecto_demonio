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
    public AudioClip Footsteps;
    public AudioClip salto;
    bool isAttacking = false;

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
        if (Input.GetButtonDown("Fire1") && !isAttacking)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    IEnumerator AttackCoroutine()
    {
        isAttacking = true;

        anim.SetTrigger("Attack1");

        AudioSource.PlayClipAtPoint(Golpe, transform.position);


        yield return new WaitForSeconds(0.5f);

        isAttacking = false;
    }


    public void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            if (audioSource != null && Footsteps != null && audioSource.clip == Footsteps && audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            AudioSource.PlayClipAtPoint(salto, transform.position);
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
        }
    }


    public void Movement()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;

        rb.velocity = new Vector2(velX * speed, velY);

        if (Mathf.Abs(rb.velocity.x) > 0 && isGrounded)
        {
            anim.SetBool("Run", true);

            if (audioSource != null && Footsteps != null && !audioSource.isPlaying)
            {
                audioSource.clip = Footsteps;
                audioSource.Play();
            }
        }
        else
        {
            anim.SetBool("Run", false);

            if (audioSource != null && Footsteps != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
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
