using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyTrap : MonoBehaviour
{
    public float speed = 5f; // Tốc độ di chuyển của bẫy gai
    public float detectionRange = 10f; // Khoảng cách mà bẫy gai có thể phát hiện Player
    private Transform player; // Tham chiếu tới Player
    private bool isPlayerDetected = false; // Kiểm tra xem Player đã bị phát hiện chưa

    void Start()
    {
        // Tìm đối tượng Player
        player = GameObject.FindWithTag("Player").transform;
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

        // Nếu Player bị phát hiện, bẫy gai di chuyển tới Player
        if (isPlayerDetected)
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
}
