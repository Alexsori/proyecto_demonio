using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class TransformacionSprite : MonoBehaviour
{
    public RuntimeAnimatorController animatorControllerInicial;
    public RuntimeAnimatorController animatorControllerNuevo;
    public float duracionTransformacion = 2f;
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

        // Cambia al Animator Controller nuevo
        Animator animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = animatorControllerNuevo;

        spriteRenderer.flipX = true;

        // Espera la duración de la transformación
        yield return new WaitForSeconds(duracionTransformacion);
        
        // Cambia de nuevo al Animator Controller inicial
        animator.runtimeAnimatorController = animatorControllerInicial;
        
        spriteRenderer.flipX = false;
        
        // Espera un tiempo antes de restablecer el sprite
        yield return new WaitForSeconds(2f);

        // Restablece el sprite original
        spriteRenderer.sprite = spriteOriginal;

        enTransformacion = false;
    }
}