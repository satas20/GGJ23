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
    private string enemyName;
    private Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").transform;
        targetPosition = GetRandomTarget();
        enemyName = this.gameObject.name;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Debug.Log(gameObject.GetComponent<Health>().death);
        if (!(gameObject.GetComponent<Health>().death))
        {
            if (enemyName == "MeleeEnemy")
            {
                MeleeEnemy();
            }
        }
        else
        {
            ceset();
        }
    }

    private void MeleeEnemy()
    {

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackCooldown && !attacking)
            {
                StartCoroutine(MeleeAttack());
            }
        }
        else if (distanceToPlayer <= chaseRange)
        {
            targetPosition = player.position;
            Move(chaseSpeed);
        }
        else
        {
          //  Debug.Log(Vector2.Distance(transform.position, targetPosition));
            if (Vector2.Distance(transform.position, targetPosition) <= 0.5f)
            {
                targetPosition = GetRandomTarget();
            }
            Move(patrolSpeed);
        }
    }

    private IEnumerator MeleeAttack()
    {
        animator.SetBool("attack", true);
        attacking = true;
        player.GetComponent<Health>().TakeDamage(damage);
        yield return new WaitForSeconds(attackCooldown);
        attackTimer = 0f;
        attacking = false;
        animator.SetBool("attack",false);
    }

    private void Move(float speed)
    {
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        rb.velocity = direction * speed;
        animator.SetBool("run", true);
    }

    private Vector2 GetRandomTarget()
    {
        if(enemyName == "MeleeEnemy")
        {
            float x = Random.Range(transform.position.x - 20f, transform.position.x + 20f);
            float y = Random.Range(transform.position.y - 20f, transform.position.y + 20f);
            return new Vector2(x, y);
        }
        else if(enemyName == "")
        {
            return new Vector2(0, 0);
        }
        else
        {
            return new Vector2(0, 0);
        }
    }

    private void ceset()
    {
        animator.SetBool("ceset",true);
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }
}
