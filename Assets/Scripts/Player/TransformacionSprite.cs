using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformacionSprite : MonoBehaviour
{
    public RuntimeAnimatorController animatorControllerInicial;
    public RuntimeAnimatorController animatorControllerNuevo;
    public float duracionTransformacion = 5f;
    private SpriteRenderer spriteRenderer;
    private Sprite spriteOriginal;
    private CapsuleCollider2D capsuleCollider;
    private bool enTransformacion = false;
    public float nuevaVelocidadLobo = 7f;
    public float antiguaVelocidad = 1f;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteOriginal = spriteRenderer.sprite;
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        
    }

    void Update()
    {
        if (!enTransformacion)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Transformacion());
            }
        }
    }

    IEnumerator Transformacion()
    {
        enTransformacion = true;

        
        if (GetComponent<PlayerController>() != null)
        {
            antiguaVelocidad = GetComponent<PlayerController>().speed;
            GetComponent<PlayerController>().speed = nuevaVelocidadLobo;
        }

        Vector2 colliderOriginalSize = capsuleCollider.size;


        Animator animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = animatorControllerNuevo;
        spriteRenderer.flipX = true;
        capsuleCollider.size = new Vector2(colliderOriginalSize.x + 0.20f, colliderOriginalSize.y - 0.60f);
        capsuleCollider.direction = CapsuleDirection2D.Horizontal;

        yield return new WaitForSeconds(duracionTransformacion);
        animator.runtimeAnimatorController = animatorControllerInicial;
        capsuleCollider.size = colliderOriginalSize;
        capsuleCollider.direction = CapsuleDirection2D.Vertical;
        spriteRenderer.flipX = false;
        GetComponent<PlayerController>().speed = antiguaVelocidad;

        yield return new WaitForSeconds(6f);
        spriteRenderer.sprite = spriteOriginal;
        enTransformacion = false;
    }
}