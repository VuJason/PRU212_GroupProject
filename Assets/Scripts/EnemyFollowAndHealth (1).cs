using UnityEngine;

public class EnemyFollowAndHealth : MonoBehaviour
{
    [Header("Di chuyển")]
    public float moveSpeed = 2f;           // Tốc độ di chuyển
    public float detectionRange = 5f;      // Phạm vi phát hiện Player

    [Header("Máu")]
    public int maxHP = 100;
    private int currentHP;

    private Transform player;

    void Start()
    {
        currentHP = maxHP;

        // Tìm Player theo tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        else
        {
            Debug.LogWarning("Không tìm thấy Player! Đảm bảo đã đặt tag 'Player' cho nhân vật.");
        }
    }

    void Update()
    {
        if (player != null && Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            MoveToPlayer();
            FlipTowardsPlayer();
        }
    }

    void MoveToPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
    }

    void FlipTowardsPlayer()
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (player.position.x < transform.position.x ? -1 : 1);
        transform.localScale = scale;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}