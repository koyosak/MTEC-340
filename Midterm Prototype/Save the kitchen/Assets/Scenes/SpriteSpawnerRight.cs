using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSpawnerRight : MonoBehaviour
{
    public GameObject spritePrefab;  // Prefab for the sprite

    public float minY = -4.3f;       // Minimum y-axis value
    public float maxY = -2.05f;      // Maximum y-axis value
    public float baseSpeed = 4f;     // Base speed for sprite movement
    public float speedFactor = 8f;          // Delay between each spawn cycle
    public float minSpawnDelay = 0.5f;  // Minimum random spawn delay
    public float maxSpawnDelay = 3f;   


    void Start()
    {

        StartCoroutine(SpawnSpriteWithRandomDelay());
        
    }

    IEnumerator SpawnSpriteWithRandomDelay()
    {
        while (true)
        {
        // Wait for a random time before spawning this sprite
        float randomDelay = Random.Range(minSpawnDelay, maxSpawnDelay);
        yield return new WaitForSeconds(randomDelay);

        // After waiting, spawn the sprite
        SpawnSpriteFromRight();
        }
    }

    void SpawnSpriteFromRight()
    {
        
        float yPos = Random.Range(minY, maxY);
        float xPos = 10f;  // Spawn position for right side

        // Instantiate the sprite prefab
        GameObject sprite = Instantiate(spritePrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);

        // Rotate the sprite 180 degrees for coming from the right
        sprite.transform.rotation = Quaternion.Euler(0, 180f, 0);  // Flip it horizontally

        // Scale the sprite based on the y-axis position
        float scale = Mathf.Lerp(1f, 0.5f, Mathf.InverseLerp(minY, maxY, yPos));
        sprite.transform.localScale = new Vector3(scale, scale, 1f);

        float adjustedSpeed = Mathf.Lerp(baseSpeed + speedFactor, baseSpeed, Mathf.InverseLerp(minY, maxY, yPos));

        StartCoroutine(MoveSprite(sprite, Vector3.left, adjustedSpeed));
    }

    IEnumerator MoveSprite(GameObject sprite, Vector3 direction, float moveSpeed)
    {
        // While the sprite is within the screen bounds (adjust the value if necessary)
        while (sprite.transform.position.x > -12f)  
        {
            // Move the sprite in the left direction (negative x)
            sprite.transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
            yield return null;
        }

        // Destroy the sprite once it moves off-screen
        Destroy(sprite);
    }
}
