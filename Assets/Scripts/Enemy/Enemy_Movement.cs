using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    public float speed;
    public float attackRange = 2;
    public float attackCooldown = 2;
    public float playerDetectRange = 5;
    public Transform detectionPoint;
    public LayerMask playerLayer;


    private float attackCooldownTimer;
    private int facingDirection =-1;
    private EnemyState enemyState;

   
    private Rigidbody2D rb;
    private Transform player;
    private Animator anim;
    

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }


    void Update()
    {
        CheckForPlayer();
        if (attackCooldown > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }


        if (enemyState == EnemyState.Chasing)
        {
           Chase();
        }
        else if (enemyState == EnemyState.Attacking)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void Chase()
    {      
        if (player.position.x > transform.position.x && facingDirection == -1 ||
                player.position.x < transform.position.x && facingDirection == 1)
        {
            Flip();
        }
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    private void Flip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);
        
        if (hits.Length > 0)
        {
            player = hits[0].transform;

            //if the player is in attack range and the attack cooldown has expired, switch to attacking state; otherwise, switch to chasing state
            if (Vector2.Distance(transform.position, player.position) < attackRange && attackCooldownTimer <= 0)
            {
                ChangeState(EnemyState.Attacking);
                attackCooldownTimer = attackCooldown;
            }
            else if (Vector2.Distance(transform.position, player.position) > attackRange)
            {
                ChangeState(EnemyState.Chasing);
            }
        }

        else
        {
                rb.linearVelocity = Vector2.zero;
                ChangeState (EnemyState.Idle);
            }
    }

    void ChangeState(EnemyState newState)
    {
        //exit current Current animations
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", false);

        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isChasing", false);

        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", false);

        //Update the enemy state
        enemyState = newState;

        //Update the animation parameters based on the new state
        if (enemyState == EnemyState.Idle)
            anim.SetBool("isIdle", true);

        else if (enemyState == EnemyState.Chasing)
            anim.SetBool("isChasing", true);

        else if (enemyState == EnemyState.Attacking)
            anim.SetBool("isAttacking", true);
    }
}

public enum EnemyState
{
    Idle,
    Chasing,
    Attacking,
}