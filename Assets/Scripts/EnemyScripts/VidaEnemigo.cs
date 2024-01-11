using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    Enemigo enemy;

    private void Start()
    {
        enemy = GetComponent<Enemigo>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            enemy.healthPoints -= 2f;


            if(enemy.healthPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
