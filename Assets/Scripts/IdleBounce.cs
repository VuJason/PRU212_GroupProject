
using UnityEngine;

public class IdleBounce : MonoBehaviour
{
    public float bounceHeight = 0.1f;     // Chiều cao nhảy
    public float bounceSpeed = 2f;        // Tốc độ nhảy

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * bounceSpeed) * bounceHeight;
        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z);
    }
}
