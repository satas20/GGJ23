using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float attackRange = 1f;
    public float attackCooldown = 1f;
    public int damage = 1;
    public float chaseRange = 30f;


    private float attackTimer;
    private bool attacking;
    private Transform player;
    private Vector2 targetPosition;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        targetPosition = GetRandomTarget();
    }

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackCooldown && !attacking)
            {
                StartCoroutine(Attack());
            }
        }
        else if (distanceToPlayer <= chaseRange)
        {
            targetPosition = player.position;
            Move(chaseSpeed);
        }
        else
        {
            if (transform.position.x == targetPosition.x && transform.position.y == targetPosition.y)
            {
                targetPosition = GetRandomTarget();
            }
            Move(patrolSpeed);
        }
    }

    private IEnumerator Attack()
    {
        attacking = true;
        player.GetComponent<Health>().TakeDamage(damage);
        yield return new WaitForSeconds(attackCooldown);
        attackTimer = 0f;
        attacking = false;
    }

    private void Move(float speed)
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        rb.velocity = direction * speed;
    }

    private Vector2 GetRandomTarget()
    {
        float x = Random.Range(transform.position.x - 20f, transform.position.x + 20f);
        float y = Random.Range(transform.position.y - 20f, transform.position.y + 20f);
        return new Vector2(x, y);
    }
}
