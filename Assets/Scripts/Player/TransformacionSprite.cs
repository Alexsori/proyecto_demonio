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
    private bool enTransformacion = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteOriginal = spriteRenderer.sprite;
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


        Animator animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = animatorControllerNuevo;
        spriteRenderer.flipX = true;
        yield return new WaitForSeconds(duracionTransformacion);
        animator.runtimeAnimatorController = animatorControllerInicial; 
        spriteRenderer.flipX = false;
        yield return new WaitForSeconds(2f);
        spriteRenderer.sprite = spriteOriginal;
        enTransformacion = false;
    }
}