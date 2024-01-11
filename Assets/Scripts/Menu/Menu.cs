using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string nextLevelName = "Mapa Nivel 1";

    void Update()
    {
        // Verifica si se presiona la tecla "Start" (puedes ajustar esto seg�n tus necesidades)
        if (Input.GetButtonDown("Start"))
        {
            // Llama a una funci�n para cargar el siguiente nivel
            Siguiente();
        }
    }

    void Siguiente()
    {
        // Carga la siguiente escena por nombre
        SceneManager.LoadScene(nextLevelName);
    }
}