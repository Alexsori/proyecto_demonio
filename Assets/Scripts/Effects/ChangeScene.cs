using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public float tiempoDeEspera = 3f;

  

    // Método que se llama cuando otro Collider2D entra en contacto con este Collider2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el objeto que entra en contacto tiene la etiqueta del jugador
        if (other.CompareTag("Player"))
        {
            // Desactiva el objeto actual
            gameObject.SetActive(false);

          

            // Inicia el temporizador para cambiar de escena después de un tiempo
            Invoke("CambiarEscena", tiempoDeEspera);
        }
    }

    // Método para cambiar de escena
    private void CambiarEscena()
    {
        // Cambia a la escena especificada en nombreDeEscena
        SceneManager.LoadScene("WinnerWin");
    }
}
