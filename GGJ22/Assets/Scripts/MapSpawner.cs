using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    public GameObject cam;
    public GameObject playerPrefab;
    public GameObject furnagePrefab;
    public int colliderRadiusFurnage;
    public GameObject kabinPrefab;
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
            GameObject kabin = kabinPrefab;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(randomPos, 0.1f);
            if (colliders.Length == 0)
            {
                Instantiate(kabin, randomPos, Quaternion.identity);

                if (i == spawnedShack)
                {
                    GameObject player = Instantiate(playerPrefab, randomPos, Quaternion.identity);
                    GameObject camera = Instantiate(cam, player.transform.position, Quaternion.identity);
                    camera.gameObject.GetComponent<CameraFollow>().target = player.transform;
                }
            }
            else
            {
                i--;
            }

        }
    }
}