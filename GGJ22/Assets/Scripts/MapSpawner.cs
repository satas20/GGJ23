using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject furnagePrefab;
    public int colliderRadiusFurnage;
    public GameObject shackPrefab;
    public int colliderRadiusShacks;
    public int numberOfShacks;
    public float mapWidth;
    public float mapHeight;

    void Start()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-mapWidth / 2, mapWidth / 2),
                                       Random.Range(-mapHeight / 2, mapHeight / 2));
        GameObject spawnedFurnage = Instantiate(furnagePrefab, spawnPos, Quaternion.identity);
        CircleCollider2D collider = spawnedFurnage.AddComponent<CircleCollider2D>();
        collider.radius = colliderRadiusFurnage;

        int spawnedShack = Random.Range(0, numberOfShacks);

        for (int i = 0; i < numberOfShacks; i++)
        {
            Vector2 randomPos = new Vector2(Random.Range(-mapWidth / 2, mapWidth / 2),
                                            Random.Range(-mapHeight / 2, mapHeight / 2));
            GameObject shack = shackPrefab;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPos, 0.1f);
            if (colliders.Length == 0)
            {
                Instantiate(shack, randomPos, Quaternion.identity);

                if (i == spawnedShack)
                {
                    Instantiate(playerPrefab, randomPos, Quaternion.identity);
                }
            }
            else
            {
                i--;
            }

        }
    }
}