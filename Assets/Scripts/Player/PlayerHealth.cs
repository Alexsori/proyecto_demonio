using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public float maxHealth;
    bool isInmune;
    public float inmunityTime;
    Blink material;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
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
