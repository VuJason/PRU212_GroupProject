using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f; // tốc độ chạy
    private bool isFacingRight = true; // trạng thái hướng mặt nhân vật
    [SerializeField]
    private Animator animator;

    private Vector2 screenBound;

    private void Start()
    {
        screenBound = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        // Nhận input ngang và dọc
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Di chuyển
        Vector3 movement = new Vector3(moveX, moveY, 0f).normalized * speed * Time.deltaTime;
        transform.Translate(movement);

        // Animation di chuyển
        bool isMoving = movement.magnitude > 0;
        animator.SetBool("1_Move", isMoving);
        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);

        // Flip trái/phải nếu có di chuyển theo X
        if (moveX > 0 && isFacingRight)
        {
            Flip();
        }
        else if (moveX < 0 && !isFacingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
    void HandleMovement()
    {

    }
}
