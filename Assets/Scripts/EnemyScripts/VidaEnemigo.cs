using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    Enemigo enemy;
    public bool isDamaged;
    public GameObject deathEffect;

    private void Start()
    {
        enemy = GetComponent<Enemigo>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && !isDamaged)
        {
            enemy.healthPoints -= 2f;
            StartCoroutine(Damager());
            
            if(enemy.healthPoints <= 0)
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }

    IEnumerator Damager()
    {
        isDamaged = true;
        yield return new WaitForSeconds(0.5f);
        isDamaged = false;
    }


}
