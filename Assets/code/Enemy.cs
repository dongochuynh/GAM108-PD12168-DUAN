using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectRange = 1f; // Phạm vi phát hiện Player nhỏ hơn
    private Transform player;
    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        // Tìm Player theo tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector2.Distance(transform.position, player.position);
            if (distance <= detectRange)
            {
                // Di chuyển về phía Player
                Vector2 direction = (player.position - transform.position).normalized;
                transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);

                // Lật sprite theo hướng di chuyển
                if (direction.x > 0)
                    sprite.flipX = false;
                else if (direction.x < 0)
                    sprite.flipX = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            // Kiểm tra Player nhảy lên đầu Enemy
            Rigidbody2D playerRb = collision.collider.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                // Nếu điểm va chạm nằm phía trên Enemy
                if (collision.contacts[0].point.y > transform.position.y + 0.2f)
                {
                    // Player bật lên
                    playerRb.linearVelocity = new Vector2(playerRb.linearVelocity.x, 8f);
                    Destroy(gameObject); // Enemy chết
                }
                else
                {
                    // Player chết
                    Destroy(collision.collider.gameObject);
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}
