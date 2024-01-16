using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector3 previousPosition;

    // On awake, get the sprite renderer component
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousPosition = transform.position;
    }

    // On update, check the direction of movement
    private void Update()
    {
        // Get the current position of the enemy
        Vector3 currentPosition = transform.position;

        // Calculate the distance between the current position and the previous position
        float distance = Vector3.Distance(previousPosition, currentPosition);

        // If the distance is greater than a threshold, then the enemy has changed direction
        if (distance > 0.1f)
        {
            // Get the direction of movement
            Vector3 direction = currentPosition - previousPosition;

            // Set the flip state
            spriteRenderer.flipX = direction.x < 0;

            // Set the previous position to the current position
            previousPosition = currentPosition;
        }
    }
}