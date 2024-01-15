using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    private bool juegoPausado = false;

    // Asegúrate de asignar este AudioSource desde el Inspector de Unity
    public AudioSource musica;

    void Update()
    {
        // Verificar si se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Cambiar el estado de pausa
            juegoPausado = !juegoPausado;

            // Llamar a la función para manejar la pausa
            ManejarPausa();
        }
    }

    void ManejarPausa()
    {
        if (juegoPausado)
        {
            // Pausar el juego
            Time.timeScale = 0f;

            // Pausar la música
            if (musica != null)
            {
                musica.Pause();
            }

            // Aquí puedes activar un menú de pausa si lo tienes
            // por ejemplo, menuPausa.SetActive(true);
        }
        else
        {
            // Despausar el juego
            Time.timeScale = 1f;

            // Reanudar la música
            if (musica != null)
            {
                musica.UnPause();
            }

            // Aquí puedes desactivar el menú de pausa si lo tienes
            // por ejemplo, menuPausa.SetActive(false);
        }
    }
}
