using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; // maximum health
    public int currentHealth; // current health
    public GameObject cesetPrefab;
    void Start()
    {
        currentHealth = maxHealth; // set initial health to maximum
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // decrease health by damage
        if (currentHealth <= 0)
        {
            Die(); // call the die function if health reaches zero
        }
    }

    void Die()
    {
        if (gameObject.CompareTag("Player"))
        {
            // handle player death
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            // handle enemy death
        }
        Instantiate(cesetPrefab, this.transform.position, Quaternion.identity);
        Destroy(gameObject);
        // destroy the game object
    }
}