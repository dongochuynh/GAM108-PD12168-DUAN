using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpikyTrap : MonoBehaviour
{
    public float speed = 5f; // Tốc độ di chuyển của bẫy gai khi bay về phía Player
    public float detectionRange = 10f; // Khoảng cách mà bẫy gai có thể phát hiện Player
    private Transform player; // Tham chiếu tới Player
    private bool isPlayerDetected = false; // Kiểm tra xem Player đã bị phát hiện chưa
    private bool hasLanded = false; // Kiểm tra xem bẫy gai đã rơi xuống đất chưa

    private Rigidbody2D rb2d; // Rigidbody2D của bẫy gai

    void Start()
    {
        // Tìm đối tượng Player
        player = GameObject.FindWithTag("Player").transform;

        // Lấy Rigidbody2D để áp dụng lực hấp dẫn và di chuyển
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Kiểm tra xem Player có trong phạm vi phát hiện không
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            isPlayerDetected = true;
        }
        else
        {
            isPlayerDetected = false;
        }

        // Nếu bẫy gai đã chạm đất và Player bị phát hiện, bẫy gai bắt đầu di chuyển tới Player
        if (hasLanded && isPlayerDetected)
        {
            MoveTowardPlayer();
        }
    }

    // Hàm di chuyển bẫy gai về phía Player
    void MoveTowardPlayer()
    {
        // Di chuyển bẫy gai về phía Player
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    // Kiểm tra khi bẫy gai chạm đất
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Nếu bẫy gai chạm đất, dừng lại và bắt đầu di chuyển về phía Player
        if (collision.collider.CompareTag("Ground"))
        {
            hasLanded = true;

            // Hủy bẫy gai sau 2 giây khi chạm đất
            Destroy(gameObject, 2f);
        }
    }
}
