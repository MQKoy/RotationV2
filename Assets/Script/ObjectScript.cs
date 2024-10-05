using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour
{
    public bool isTrap; // Set to true for obstacles and false for collectibles
    [SerializeField] private float moveSpeed = 5f; // Speed of movement

    private void Start()
    {
        // Destroy the GameObject after 5 seconds if it doesn't collide
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        // Move the object to the right
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isTrap)
            {
                Debug.Log("Hit an obstacle!"); // Debug message for obstacle hit
                GameManager.instance.DeathScreen(); // Show Game Over UI
                Destroy(other.gameObject); // Destroy the player
            }
            else
            {
                Debug.Log("Collected a collectible!"); // Debug message for collectible
                GameManager.instance.AddScore(); // Increment score
                Destroy(gameObject); // Destroy the collectible
            }
        }
    }
}

