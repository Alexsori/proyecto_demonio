using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parpadeitoo : MonoBehaviour
{
    public float Segundos = 0.5f; // Intervalo de parpadeo en segundos
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(Parpadeo());
    }

    IEnumerator Parpadeo()
    {
        while (true)
        {
            // Alternar entre transparente y opaco cambiando el canal alpha del material
            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 0f);
            yield return new WaitForSeconds(Segundos);

            rend.material.color = new Color(rend.material.color.r, rend.material.color.g, rend.material.color.b, 1f);
            yield return new WaitForSeconds(Segundos);
        }
    }
}
