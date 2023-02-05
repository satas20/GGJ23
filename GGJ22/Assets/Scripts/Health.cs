using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; // maximum health
    public int currentHealth; // current health
    public GameObject cesetPrefab;
    public ParticleSystem blood;
    public GameObject endGameScreen;
    public GameObject levelUi;

    void Start()
    {
        currentHealth = maxHealth; // set initial health to maximum
    }

    public void TakeDamage(int damage)
    {
        blood.Play();
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
            endGameScreen.SetActive(true);
            levelUi.SetActive(false);
            Destroy(gameObject.GetComponent<Shooting>());
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Instantiate(cesetPrefab, this.transform.position, Quaternion.identity);

            // handle enemy death
        }
        // destroy the game object
    }
}