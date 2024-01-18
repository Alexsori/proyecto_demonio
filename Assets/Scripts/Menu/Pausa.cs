using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausa : MonoBehaviour
{
    public GameObject panelPausa; // Asigna el panel de pausa desde el Inspector
    private bool juegoPausado = false;

    void Start()
    {
        // Asegúrate de que el juego no esté pausado al inicio
        Time.timeScale = 1f;
        panelPausa.SetActive(false);
    }

    void Update()
    {
        // Comprueba si se ha presionado la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                ContinuarJuego();
            }
            else
            {
                PausarJuego();
            }
        }
    }

    void PausarJuego()
    {
        juegoPausado = true;
        Time.timeScale = 0f; // Detiene el tiempo en el juego
        panelPausa.SetActive(true); // Activa el panel de pausa
    }

    void ContinuarJuego()
    {
        juegoPausado = false;
        Time.timeScale = 1f; // Reanuda el tiempo en el juego
        panelPausa.SetActive(false); // Desactiva el panel de pausa
    }
}