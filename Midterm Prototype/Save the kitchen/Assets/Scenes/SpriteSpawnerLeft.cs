using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpawnerLeft : MonoBehaviour
{
    public GameObject spritePrefab;  // Prefab for the sprite
    public float minY = -4.3f;       // Minimum y-axis value
    public float maxY = -2.05f;      // Maximum y-axis value
    public float baseSpeed = 4f;     // Base speed for sprite movement
    public float speedFactor = 8f;          // Speed of sprite movement
    public float minSpawnDelay = 0.5f;  // Minimum random spawn delay
    public float maxSpawnDelay = 3f;   

    void Start()
    {
       
        StartCoroutine(SpawnSpriteWithRandomDelay());
    }

    IEnumerator SpawnSpriteWithRandomDelay()
    {
        while (true) // Infinite loop to keep spawning
        {
            // Wait for a random time before spawning the next sprite
            float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(randomDelay);

            // Spawn the sprite from the left side
            SpawnSpriteFromLeft();
        }
    }
    void SpawnSpriteFromLeft()
    {
       
        float yPos = Random.Range(minY, maxY);
        float xPos = -10f;  // Spawn position for left side

        // Instantiate the sprite prefab
        GameObject sprite = Instantiate(spritePrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);

        // Rotate the sprite 0 degrees for coming from the left (default)
        sprite.transform.rotation = Quaternion.Euler(0, 0, 0);

        // Scale the sprite based on the y-axis position
        float scale = Mathf.Lerp(1f, 0.5f, Mathf.InverseLerp(minY, maxY, yPos));
        sprite.transform.localScale = new Vector3(scale, scale, 1f);

        float adjustedSpeed = Mathf.Lerp(baseSpeed + speedFactor, baseSpeed, Mathf.InverseLerp(minY, maxY, yPos));

        StartCoroutine(MoveSprite(sprite, Vector3.right, adjustedSpeed));
    }

    IEnumerator MoveSprite(GameObject sprite, Vector3 direction, float moveSpeed)
    {
        while ((sprite.transform.position.x) < 12f)  // Continue moving until off-screen
        {
            sprite.transform.Translate(direction * moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Destroy the sprite once it moves off-screen
        Destroy(sprite);
    }
}
