using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Corazon;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthImg;
    bool isInmune;
    public float inmunityTime;
    Blink material;
    SpriteRenderer sprite;
    public float knockbackForceX;
    public float knockbackForceY;
    Animator anim;
    public TextMeshProUGUI mensajeTexto;


    public void AumentarVida(int incremento)
    {
        health += incremento;
       
    }
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        health = maxHealth;
    }

    private void Update()
    {
        healthImg.fillAmount = health / maxHealth;

        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemigo") && !isInmune)
        {
            health -= collision.GetComponent<Enemigo>().damageToGive;

            StartCoroutine(Inmunity());

            if (health <= 0)
            {
                print("player dead");
                //anim.SetTrigger("Death");
            }
        }
        else if (collision.CompareTag("Heart"))
        {
            // Aumenta la vida m�xima del jugador
            AumentarVidaMaxima(collision.GetComponent<Corazon>().vidaAumentada);

            // Destruye el coraz�n
            Destroy(collision.gameObject);
        }
    }

    IEnumerator Inmunity()
    {
        isInmune = true;
        yield return new WaitForSeconds(inmunityTime);
        isInmune = false;
    }

    public void AumentarVidaMaxima(int cantidad)
    {
        maxHealth += cantidad;
        health = maxHealth; // Tambi�n puedes ajustar la salud actual si lo prefieres.
        Debug.Log("Vida m�xima aumentada a: " + maxHealth);
    }
}
