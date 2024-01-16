using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // On awake, get the sprite renderer component
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // On update, check the direction of movement
    private void Update()
    {
        // If the enemy is moving to the left, don't flip the sprite
        if (transform.localScale.x < 0)
        {
            spriteRenderer.flipX = false;
        }

        // If the enemy is moving to the right, flip the sprite
        else
        {
            spriteRenderer.flipX = true;
        }
    }
}