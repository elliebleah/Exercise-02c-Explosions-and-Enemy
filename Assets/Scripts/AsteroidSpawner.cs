using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public GameObject[] asteroidGameObjects;
    public float spawnInterval = 1f;

    public float[] shifters = new float[4] {270, 180, 90, 0};

    public GameObject asteroidHolder;

    void Start()
    {
        
        // Start the spawning coroutine
        StartCoroutine(SpawnAsteroidsCoroutine());
    }

    IEnumerator SpawnAsteroidsCoroutine()
    {
        while (true)
        {
            // Call the spawner method
            SpawnAsteroidOnRandomSprite(asteroidGameObjects);

            // Wait for the specified interval before spawning the next asteroid
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnAsteroidOnRandomSprite(GameObject[] asteroidObjects)
    {
        // Pick a random GameObject from the array
        int index = Random.Range(0, asteroidObjects.Length);
        GameObject randomObject = asteroidObjects[index];

        // Get the Sprite component of the selected GameObject
        SpriteRenderer spriteRenderer = randomObject.GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && spriteRenderer.sprite != null)
        {
            // Get a random position within the bounds of the sprite
            Vector2 randomPosition = new Vector2(
                Random.Range(spriteRenderer.bounds.min.x, spriteRenderer.bounds.max.x),
                Random.Range(spriteRenderer.bounds.min.y, spriteRenderer.bounds.max.y)
            );

            // Instantiate the asteroid prefab at the random position
            //Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);
            GameObject asteroidObject = Instantiate(asteroidPrefab, randomPosition, Quaternion.identity);

            asteroidObject.transform.SetParent(asteroidHolder.transform);

// Get the Asteroid component from the instantiated asteroid GameObject
            Asteroid asteroid = asteroidObject.GetComponent<Asteroid>();
            if (asteroid != null)
            {
                asteroid.shift = shifters[index];
                asteroid.move();
            }
        }
        else
        {
            Debug.LogWarning("SpriteRenderer or Sprite is missing in the selected GameObject.");
        }
    }
}