using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [Header("Attack Settings")]
    public Transform attackPoint;                 // Điểm bắt đầu tấn công
    public float attackRange = 0.5f;

    public int minDamage;
    public int maxDamage;

    private Animator animator;
   

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("2_Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        foreach (Collider2D col in hitEnemies)
        {
            if (col.CompareTag("Enemy")) // ← Kiểm tra theo tag
            {
                EnemyHealth enemyHealth = col.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    int damage = Random.Range(minDamage, maxDamage + 1);
                    enemyHealth.TakeDamage(damage);
                    Debug.Log($"Gây {damage} damage cho {col.name}");
                }
            }
        }
    }
}
