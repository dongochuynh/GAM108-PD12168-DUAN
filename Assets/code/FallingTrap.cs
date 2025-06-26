using UnityEngine;

public class FallingTrap : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool hasFallen = false;

    public float detectRadius = 3f; // Phạm vi phát hiện Player
    public LayerMask playerLayer;   // Chọn layer của Player trong Inspector
    public Vector2 detectOffset = Vector2.zero; // Để chỉnh offset

    public float fastGravityScale = 10f; // Gravity khi rơi trong nước
    private float originalGravityScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic; // Ban đầu không rơi
        originalGravityScale = rb.gravityScale;
    }

    void Update()
    {
        if (!hasFallen)
        {
            Vector2 detectCenter = (Vector2)transform.position + detectOffset;
            Collider2D hit = Physics2D.OverlapCircle(detectCenter, detectRadius, playerLayer);
            if (hit != null && hit.CompareTag("Player"))
            {
                StartFalling();
            }
        }
    }

    // Gọi hàm này để bẫy bắt đầu rơi
    public void StartFalling()
    {
        if (!hasFallen)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            hasFallen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
        // KHÔNG xử lý gì với nước ở đây!
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            rb.gravityScale = originalGravityScale; // Trả lại gravity bình thường nếu cần
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 detectCenter = (Vector2)transform.position + detectOffset;
        Gizmos.DrawWireSphere(detectCenter, detectRadius);
    }
}
