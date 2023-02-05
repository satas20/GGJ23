using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate;
    private Vector2 spawnPosition;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 12f;
        timer = spawnRate;

    }

    private void FixedUpdate()
    {
        if(timer > 0)
        {
            timer -= Time.fixedDeltaTime;
            
        }
        else
        {
            int spawnPosX = Random.Range(0, 245);
            int spawnPosY = Random.Range(0, 279);

            spawnPosition = new Vector2(transform.position.x + spawnPosX, transform.position.y + spawnPosY);

            timer = spawnRate;
            Instantiate(enemyPrefab,spawnPosition,Quaternion.identity);
        }
    }
}
