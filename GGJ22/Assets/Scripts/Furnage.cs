using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnage : MonoBehaviour
{
    public float mapWidth = 100f;
    public float mapHeight = 100f;
    public float colliderRadius = 1f;
    public bool enteredPlayer = false;

    void Start()
    {
        float x = Random.Range(-mapWidth / 2, mapWidth / 2);
        float y = Random.Range(-mapHeight / 2, mapHeight / 2);
        transform.position = new Vector2(x, y);

        int rotation = Random.Range(0, 4) * 90;
        transform.rotation = Quaternion.Euler(0, 0, rotation);

        CircleCollider2D collider = gameObject.AddComponent<CircleCollider2D>();
        collider.radius = colliderRadius;
        collider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enteredPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enteredPlayer = false;
        }
    }
}
