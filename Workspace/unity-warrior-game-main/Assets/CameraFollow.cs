using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public Transform target;       // Đối tượng cần follow (player)
    public Vector3 offset;         // Khoảng cách giữa camera và player
    public float smoothSpeed = 0.125f;  // Độ mượt

    void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Nếu muốn camera luôn nhìn vào player (tùy chọn):
        transform.LookAt(target);
    }
}
