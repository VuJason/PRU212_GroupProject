using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float moveSpeed = 2f;  // tốc độ di chuyển

    private Transform player;

    void Start()
    {
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
        if (player != null)
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
        if (player.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1); // quay trái
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);  // quay phải
        }
    }
}
