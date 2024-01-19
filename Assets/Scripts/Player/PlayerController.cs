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
    public AudioSource audioSource2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource2 = gameObject.AddComponent<AudioSource>();
        audioSource2.playOnAwake = false;
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
            isAttacking = true;
            anim.SetTrigger("Attack1");

            if (audioSource != null && Golpe != null)
            {
                audioSource.PlayOneShot(Golpe);
            }

            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
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

            if (audioSource2 != null && Footsteps != null && !audioSource2.isPlaying)
            {
                audioSource2.clip = Footsteps;
                audioSource2.Play();
            }
        }
        else
        {
            anim.SetBool("Run", false);

            // Detener el sonido solo si estaba reproduciéndose y no se está realizando otra acción (por ejemplo, pegar)
            if (audioSource2 != null && Footsteps != null && audioSource2.isPlaying && !isAttacking)
            {
                audioSource2.Stop();
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
