using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //Rigidbody2D rb;
  
    void Start()
    {
        //rb = GetComponent<SpriteRenderer>();
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        health = maxHealth;
    }

    // Update is called once per frame
   private void Update()
    {
        healthImg.fillAmount = health / 100;


        if(health> maxHealth)
        {
            health = maxHealth;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemigo") && !isInmune)
        {
            health -= collision.GetComponent<Enemigo>().damageToGive;
           
            //rb.AddForce(new Vector2 (Enemigo.knockbackForceX, Enemigo.knockbackForceY), ForceMode2D.Force);
            
            
            StartCoroutine(Inmunity());

           


            if(health <=0)
            {
                print("player dead");
            }
        }
    }

    IEnumerator Inmunity()
    {

        isInmune = true;
        //sprite.material = material.blink;
        yield return new WaitForSeconds(0.5f);
        //sprite.material = material.original;
        isInmune = false;
    }

}
