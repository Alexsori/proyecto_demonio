using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creditos : MonoBehaviour
{
    void Start()
    {
        // Llama a la funci�n CloseGame despu�s de 15 segundos
        Invoke("CloseGame", 15f);
    }

    void CloseGame()
    {
        // Cierra el juego
        Application.Quit();
    }
}
