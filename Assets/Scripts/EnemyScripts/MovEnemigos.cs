using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GridBrushBase;

public class MovEnemigos : MonoBehaviour
{
    float speed;
    Rigidbody2D rb;
    Animator anim;

    public bool isStatic;
    public bool isWalker;
    public bool isPatrol;
    public bool shouldWait;
    public float timeToWait;
    public bool isWaiting;
    public bool walksRight;

    public Transform wallCheck, pitCheck, groundCheck;
    public bool wallDetected, pitDetected, isGrounded;
    public float detectionRadius;
    public LayerMask whatIsGround;

    public Transform pointA, pointB;
    public bool goToA, goToB;
    private SpriteRenderer spriteRenderer;


    // Start is called before the first frame update
    void Start()
    {
        goToA = true;
        speed = GetComponent<Enemigo>().speed;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        pitDetected = !Physics2D.OverlapCircle(pitCheck.position, detectionRadius, whatIsGround);
        wallDetected = Physics2D.OverlapCircle(wallCheck.position, detectionRadius, whatIsGround);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, detectionRadius, whatIsGround);


        if (pitDetected || wallDetected && isGrounded)
        {
           // Flip();
        }
    }


    private void FixedUpdate()
    {
        if (isStatic)
        {
            anim.SetBool("idle", true);
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (isWalker)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            anim.SetBool("idle", false);

            if (!walksRight)
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
        }
        if (isPatrol)
        {

            if (goToA)
            {
                if (!isWaiting)
                {
                    anim.SetBool("idle", false);
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                }


                if (Vector2.Distance(transform.position, pointA.position) < 2f)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }

                    //Flip();
                    goToA = false;
                    goToB = true;
                }
            }

            if (goToB)
            {

                if (!isWaiting)
                {
                    anim.SetBool("idle", false);
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                }

                if (Vector2.Distance(transform.position, pointB.position) < 2f)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }

                   // Flip();
                    goToA = true;
                    goToB = false;
                }
            }
        }
    }

    IEnumerator Waiting()
    {
        anim.SetBool("idle", true);
        isWaiting = true;
       // Flip();
        yield return new WaitForSeconds(timeToWait);
        isWaiting = false;
        anim.SetBool("idle", false);
       // Flip();
    }
    public void Flip()
    {
       // SpriteRenderer.FlipX = true;
       // walksRight = !walksRight;
        //transform.localScale = new Vector2(-4, transform.localScale.x);
    }
}

   


