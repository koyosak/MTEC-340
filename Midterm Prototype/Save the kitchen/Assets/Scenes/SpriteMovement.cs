using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteMovement : MonoBehaviour
{
    public GameObject spritePrefab;  // Prefab for the sprite
    public int numberOfSprites;      // Number of sprites to instantiate
    public float minY = -4.3f;       // Minimum y-axis value
    public float maxY = -2.05f;      // Maximum y-axis value
    public float speed = 2f;          // Speed of sprite movement
    public float spawnDelay;          // Delay between each spawn cycle

    void Start()
    {
        StartCoroutine(SpawnSprites());
    }

    IEnumerator SpawnSprites()
    {
        while (true)
        {
            // Spawn sprites from the right side
            for (int i = 0; i < numberOfSprites; i++)
            {
                SpawnSpriteFromRight();
            }

            // Spawn sprites from the left side
            for (int i = 0; i < numberOfSprites; i++)
            {
                SpawnSpriteFromLeft();
            }

            // Wait for some time before spawning more sprites
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnSpriteFromRight()
    {
        // Randomly choose y-axis within the given range
        float yPos = Random.Range(minY, maxY);
        float xPos = 10f;  // Spawn position for right side

        // Instantiate the sprite prefab
        GameObject sprite = Instantiate(spritePrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);

        // Rotate the sprite 180 degrees for coming from the right
        sprite.transform.rotation = Quaternion.Euler(0, 180f, 0);

        // Scale the sprite based on the y-axis position
        float scale = Mathf.Lerp(1f, 0.5f, Mathf.InverseLerp(minY, maxY, yPos));
        sprite.transform.localScale = new Vector3(scale, scale, 1f);

        // Move the sprite across the screen to the left
        StartCoroutine(MoveSprite(sprite, Vector3.left));
    }

    void SpawnSpriteFromLeft()
    {
        // Randomly choose y-axis within the given range
        float yPos = Random.Range(minY, maxY);
        float xPos = -10f;  // Spawn position for left side

        // Instantiate the sprite prefab
        GameObject sprite = Instantiate(spritePrefab, new Vector3(xPos, yPos, 0), Quaternion.identity);

        // Rotate the sprite 0 degrees for coming from the left (default)
        sprite.transform.rotation = Quaternion.Euler(0, 0, 0);

        // Scale the sprite based on the y-axis position
        float scale = Mathf.Lerp(1f, 0.5f, Mathf.InverseLerp(minY, maxY, yPos));
        sprite.transform.localScale = new Vector3(scale, scale, 1f);

        // Move the sprite across the screen to the right
        StartCoroutine(MoveSprite(sprite, Vector3.right));
    }

    IEnumerator MoveSprite(GameObject sprite, Vector3 direction)
    {
        while (Mathf.Abs(sprite.transform.position.x) < 12f)  // Continue moving until off-screen
        {
            sprite.transform.Translate(direction * speed * Time.deltaTime);
            yield return null;
        }

        // Destroy the sprite once it moves off-screen
        Destroy(sprite);
    }
}
