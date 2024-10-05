using System.Collections;
using UnityEngine;

public class TrapSpawner : MonoBehaviour
{
    public GameObject[] Obstacles; // Array of obstacle prefabs
    public GameObject Collectible;  // Reference to the collectible prefab
    public Transform LeftSpawner; // Left spawn point
    public float RandomYOffsetMinimum = -3f; // Minimum Y offset for spawning
    public float RandomYOffsetMaximum = 3f; // Maximum Y offset for spawning
    public float spawnDelay = 2f; // Time between spawns

    void Start()
    {
        InvokeRepeating("SpawnObjects", 1f, spawnDelay);
    }

    void SpawnObjects()
    {
        // Determine random Y position for spawning within specified range
        float randomYOffset = Random.Range(RandomYOffsetMinimum, RandomYOffsetMaximum);

        // Randomly choose between an obstacle and a collectible
        if (Random.value > 0.5f)
        {
            int randomIndex = Random.Range(0, Obstacles.Length);
            GameObject obstacle = Instantiate(Obstacles[randomIndex], LeftSpawner.position + new Vector3(0, randomYOffset, 0), Quaternion.identity);
            obstacle.GetComponent<ObjectScript>().isTrap = true; // Set isTrap to true for obstacles
        }
        else
        {
            GameObject collectible = Instantiate(Collectible, LeftSpawner.position + new Vector3(0, randomYOffset, 0), Quaternion.identity);
            collectible.GetComponent<ObjectScript>().isTrap = false; // Set isTrap to false for collectibles
        }
    }
}