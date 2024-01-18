using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    public float daño = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jugador")
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= daño;
        }
    }
}
