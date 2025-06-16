using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float runSpeed = 5f; // tốc độ chạy
    private bool isFacingRight = true; // trạng thái hướng mặt nhân vật
    public Animator anim;

    void Update()
    {
        // Nhận input ngang (trái/phải) và dọc (lên/xuống)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Tạo vector di chuyển 2 chiều
        Vector3 movement = new Vector3(moveX, moveY, 0) * runSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Lật nhân vật nếu đi trái/phải
        if (moveX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveX < 0 && isFacingRight)
        {
            Flip();
        }
        anim.SetFloat("di chuyen", Mathf.Abs(moveX));
    }


    void Flip()
    {
        // Đảo hướng mặt nhân vật bằng cách scale X = -1
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
