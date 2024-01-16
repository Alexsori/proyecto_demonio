using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformacionSprite1 : MonoBehaviour
{
    public RuntimeAnimatorController animatorControllerInicial;
    public RuntimeAnimatorController animatorControllerNuevo;
    public float duracionTransformacion = 5f;
    public float nuevoTamaño = 2f; // Ajusta según tus necesidades
    public KeyCode teclaTransformacion = KeyCode.E; // Ajusta según tus necesidades

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

        // Cambiar la escala del objeto y el tamaño del Collider
        CambiarTamaño();

        yield return new WaitForSeconds(duracionTransformacion);

        animator.runtimeAnimatorController = animatorControllerInicial;
        spriteRenderer.flipX = false;

        yield return new WaitForSeconds(2f);

        // Restaurar la escala original y el tamaño del Collider
        RestaurarTamaño();

        spriteRenderer.sprite = spriteOriginal;
        enTransformacion = false;
    }

    void CambiarTamaño()
    {
        if (miCollider != null)
        {
            transform.localScale = new Vector3(nuevoTamaño, nuevoTamaño, nuevoTamaño);

            if (miCollider is BoxCollider)
            {
                ((BoxCollider)miCollider).size = escalaOriginal * nuevoTamaño;
            }
            else if (miCollider is SphereCollider)
            {
                ((SphereCollider)miCollider).radius = (escalaOriginal.x + escalaOriginal.y + escalaOriginal.z) / 6 * nuevoTamaño;
            }
        }
    }

    void RestaurarTamaño()
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