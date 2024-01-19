using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    public GameObject FalseWall;


    void Start()
    {
        FalseWall.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            FalseWall.SetActive(false);

            { }
            }
        }
    }

    
    

