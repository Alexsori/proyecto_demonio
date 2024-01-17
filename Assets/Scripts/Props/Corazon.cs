using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Corazon : MonoBehaviour
{
    public int vidaAumentada = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            // Aumenta la vida máxima del jugador
            playerHealth.AumentarVidaMaxima(vidaAumentada);

            // Muestra el mensaje en el objeto de texto
            if (playerHealth.mensajeTexto != null)
            {
                playerHealth.mensajeTexto.text = "Has aumentado tu vida máxima!";
                // Comienza la corrutina para hacer que el mensaje desaparezca después de 3 segundos
                playerHealth.StartCoroutine(DesaparecerMensaje(playerHealth.mensajeTexto));
            }

            // Destruye el corazón
            Destroy(gameObject);
        }
    }

    IEnumerator DesaparecerMensaje(TextMeshProUGUI mensajeText)
    {
        yield return new WaitForSeconds(3f);
        mensajeText.text = "";
    }
}
