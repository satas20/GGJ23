using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRate;
    private Vector2 spawnPosition;
    private float timer;
    public GameObject[] cephaneler;
    private float spawnRateAmmo;
    private float timer2;
    private Vector2 spawnPosition2;


    // Start is called before the first frame update
    void Start()
    {
        spawnRate = 12f;
        timer = spawnRate;
        spawnRateAmmo = 10f;
        timer2 = spawnRateAmmo;
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

        if (timer2 > 0)
        {
            timer2 -= Time.fixedDeltaTime;

        }
        else
        {
            int spawnPosX2 = Random.Range(0, 245);
            int spawnPosY2 = Random.Range(0, 279);

            spawnPosition2 = new Vector2(transform.position.x + spawnPosX2, transform.position.y + spawnPosY2);

            timer2 = spawnRateAmmo;
            Instantiate(cephaneler[Random.Range(0, 2)], spawnPosition2, Quaternion.identity);
        }
    }
}
