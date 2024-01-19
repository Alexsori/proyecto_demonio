using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuente : MonoBehaviour
{
    public int vidaIncremento = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth vidaJugador = other.GetComponent<PlayerHealth>();

            if (vidaJugador != null)
            {
                vidaJugador.AumentarVida(vidaIncremento);
                Destroy(gameObject);
            }
        }
    }
}