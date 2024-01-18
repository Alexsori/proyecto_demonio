using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigo : MonoBehaviour
{
    [SerializeField] private Healthbar healthbar;
    [SerializeField] private float maxHealth;
    private float health;
    public Image hpEnemigo;

    Enemigo enemy;
    public bool isDamaged;
    public GameObject deathEffect;
    SpriteRenderer sprite;
    Blink material;
    Rigidbody2D rb;

    private void Start()
    {
        health = maxHealth;
        healthbar.UpdateHealthbar(maxHealth, health);
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        material = GetComponent<Blink>();
        enemy = GetComponent<Enemigo>();
    }

    private void Update()
    {
        hpEnemigo.fillAmount = health / maxHealth;

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && !isDamaged)
        {
            // Reducir la salud del enemigo
            enemy.healthPoints -= 2f;
            healthbar.UpdateHealthbar(maxHealth, health);
            // Aplicar efecto de golpe y knockback
            ApplyHitEffect(collision);

            // Iniciar la corrutina para el destello blanco
            StartCoroutine(FlashWhite());

            // Verificar si el enemigo debe ser destruido
            if (enemy.healthPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void ApplyHitEffect(Collider2D collision)
    {
        // Aplicar knockback
        if (collision.transform.position.x < transform.position.x)
        {
            rb.AddForce(new Vector2(enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
        }
        else
        {
            rb.AddForce(new Vector2(-enemy.knockbackForceX, enemy.knockbackForceY), ForceMode2D.Force);
        }

        // Iniciar la corrutina para el parpadeo de daño
        StartCoroutine(FlashWhite());
    }

    IEnumerator Damager()
    {
        isDamaged = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
        sprite.material = material.blink;
    }

    IEnumerator FlashWhite()
    {
        isDamaged = true;
        sprite.color = Color.white;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
        sprite.color = Color.white;
    }

    void ActivateDeathAnimation()
    {
        // Activa la animación mediante el Animator
        Animator animator = deathEffect.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetTrigger("DestroyTrigger");
        }
    }
}
