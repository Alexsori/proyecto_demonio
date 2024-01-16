using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformacionSprite1 : MonoBehaviour
{
    public RuntimeAnimatorController animatorControllerInicial;
    public RuntimeAnimatorController animatorControllerNuevo;
    public float duracionTransformacion = 5f;
    public float nuevoTama�o = 2f; // Ajusta seg�n tus necesidades
    public KeyCode teclaTransformacion = KeyCode.E; // Ajusta seg�n tus necesidades

    private SpriteRenderer spriteRenderer;
    private Sprite spriteOriginal;
    private bool enTransformacion = false;
    private Collider miCollider;
    private Vector3 escalaOriginal;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteOriginal = spriteRenderer.sprite;
        miCollider = GetComponent<Collider>();

        if (miCollider == null)
        {
            Debug.LogError("Este objeto no tiene un Collider adjunto.");
        }

        escalaOriginal = transform.localScale;
    }

    void Update()
    {
        if (!enTransformacion)
        {
            if (Input.GetKeyDown(teclaTransformacion))
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

        // Cambiar la escala del objeto y el tama�o del Collider
        CambiarTama�o();

        yield return new WaitForSeconds(duracionTransformacion);

        animator.runtimeAnimatorController = animatorControllerInicial;
        spriteRenderer.flipX = false;

        yield return new WaitForSeconds(2f);

        // Restaurar la escala original y el tama�o del Collider
        RestaurarTama�o();

        spriteRenderer.sprite = spriteOriginal;
        enTransformacion = false;
    }

    void CambiarTama�o()
    {
        if (miCollider != null)
        {
            transform.localScale = new Vector3(nuevoTama�o, nuevoTama�o, nuevoTama�o);

            if (miCollider is BoxCollider)
            {
                ((BoxCollider)miCollider).size = escalaOriginal * nuevoTama�o;
            }
            else if (miCollider is SphereCollider)
            {
                ((SphereCollider)miCollider).radius = (escalaOriginal.x + escalaOriginal.y + escalaOriginal.z) / 6 * nuevoTama�o;
            }
        }
    }

    void RestaurarTama�o()
    {
        if (miCollider != null)
        {
            transform.localScale = escalaOriginal;

            if (miCollider is BoxCollider)
            {
                ((BoxCollider)miCollider).size = escalaOriginal;
            }
            else if (miCollider is SphereCollider)
            {
                ((SphereCollider)miCollider).radius = (escalaOriginal.x + escalaOriginal.y + escalaOriginal.z) / 6;
            }
        }
    }
}