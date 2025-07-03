using UnityEngine;

public class run : MonoBehaviour
{
    public float runSpeed = 5f; // Tốc độ chạy
    private bool isFacingRight = false; // NHÂN VẬT MẶC ĐỊNH NHÌN TRÁI
    public Animator anim;

    void Update()
    {
        // Nhận input từ người chơi
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Tạo vector di chuyển
        Vector3 movement = new Vector3(moveX, moveY, 0) * runSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Lật hướng nhân vật nếu cần
        if (moveX > 0 && !isFacingRight)
        {
            Flip(); // Nhấn phải nhưng đang nhìn trái → lật sang phải
        }
        else if (moveX < 0 && isFacingRight)
        {
            Flip(); // Nhấn trái nhưng đang nhìn phải → lật sang trái
        }

        // Gửi tốc độ di chuyển cho animator
        anim.SetFloat("di chuyen", Mathf.Abs(moveX));
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;

        // Nếu nhân vật mặc định nhìn TRÁI:
        // Lật sang phải thì X = -|x|, lật lại trái thì X = |x|
        if (isFacingRight)
        {
            localScale.x = -Mathf.Abs(localScale.x); // Nhìn phải
        }
        else
        {
            localScale.x = Mathf.Abs(localScale.x); // Nhìn trái
        }

        transform.localScale = localScale;
    }
}
