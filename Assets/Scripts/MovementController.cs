using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Animator animator;

    // Tham chiếu tới Transform để flip (nếu là nhân vật nhiều layer)
    public Transform graphicsRoot; // Kéo GameObject chứa các layer vào đây (ví dụ: Root hoặc BodySet)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        // Nếu chưa gán graphicsRoot, mặc định là chính object này
        if (graphicsRoot == null)
            graphicsRoot = this.transform;
    }

    void Update()
    {
        // Lấy input từ bàn phím
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Normal hóa để tránh di chuyển chéo quá nhanh
        movement = movement.normalized;

        // Debug input
        // Debug.Log($"Input: {movement}");

        // Cập nhật animation
        if (animator != null)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }

        // Flip đúng hướng: Giả sử hướng mặc định là phải (x=1)
        if (movement.x > 0)
            graphicsRoot.localScale = new Vector3(1, graphicsRoot.localScale.y, graphicsRoot.localScale.z);
        else if (movement.x < 0)
            graphicsRoot.localScale = new Vector3(-1, graphicsRoot.localScale.y, graphicsRoot.localScale.z);
    }

    void FixedUpdate()
    {
        // Di chuyển nhân vật
        rb.linearVelocity = movement * moveSpeed;
    }
}
