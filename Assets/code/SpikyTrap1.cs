using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikyTrap1 : MonoBehaviour
{
    // Khi Player va chạm với bẫy gai, bẫy gai sẽ hủy Player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu đối tượng va chạm là Player
        if (collision.collider.CompareTag("Player"))
        {
            // Gọi hàm để làm Player chết (hủy đối tượng Player)
            KillPlayer(collision.collider.gameObject);

            // Hủy bẫy gai (tùy chọn, nếu bạn muốn bẫy gai biến mất sau khi va chạm)
            Destroy(gameObject);
        }
    }

    // Hàm để làm Player chết (hủy Player)
    void KillPlayer(GameObject player)
    {
        // Bạn có thể làm Player chết theo nhiều cách:
        // Ví dụ, hủy đối tượng Player hoàn toàn
        Destroy(player); // Hủy Player khỏi cảnh

        // Hoặc nếu bạn không muốn hủy, có thể tắt nó đi:
        // player.SetActive(false); // Tắt Player đi mà không hủy
    }
}
