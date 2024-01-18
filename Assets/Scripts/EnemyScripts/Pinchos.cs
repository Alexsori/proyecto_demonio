using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    public float da�o = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Jugador")
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= da�o;
        }
    }
}
