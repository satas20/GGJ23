using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // damage dealt by the bullet
 


   

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            // deal damage to the enemy
            collider.GetComponent<Health>().TakeDamage(damage);
        }
        // destroy the bullet
        Destroy(gameObject);
    }
}