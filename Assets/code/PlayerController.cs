using UnityEngine;

// Ensure the Bullet class is defined and accessible
public class Bullet : MonoBehaviour
{
    public Vector2 bulletDirection; // Renamed to avoid ambiguity

    void Update()
    {
        // Example movement logic for the bullet
        transform.Translate(bulletDirection * Time.deltaTime);
    }
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;

    public float movespeed = 2f;
    public float jumpForce = 3f;
    private bool canClimb = false;
    public float climbSpeed = 2f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Lấy đầu vào chuyển động ngang (trái/phải)
        float moveInput = Input.GetAxis("Horizontal");

        // Cập nhật vận tốc của Rigidbody2D (chỉ thay đổi vận tốc ngang)
        rb.linearVelocity = new Vector2(moveInput * movespeed, rb.linearVelocity.y);

        // Cập nhật tham số "xVel" để điều khiển hoạt ảnh
        animator.SetFloat("xVel", Mathf.Abs(moveInput));

        // Kiểm tra trạng thái chạy (Running)
        if (Mathf.Abs(moveInput) > 0.01f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        // Quay nhân vật qua lại (lật hình ảnh của nhân vật)
        if (moveInput > 0)
        {
            sprite.flipX = false;
        }
        else if (moveInput < 0)
        {
            sprite.flipX = true;
        }

        // Xử lý nhảy (phím Space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            animator.SetTrigger("doJump");
        }

        // Xử lý lăn (phím Shift trái/phải)
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && Mathf.Abs(moveInput) > 0.1f)
        {
            animator.SetTrigger("doRoll");
            animator.SetBool("isRunning", false);
        }

        // Xử lý leo (phím F)
        if (Input.GetKey(KeyCode.F) && canClimb)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, climbSpeed);
            animator.SetTrigger("isEscalate");
        }

        // Xử lý trạng thái lo lắng (phím G)
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetTrigger("isWorried");
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Stairs"))
        {
            canClimb = true;
        }
        else if (collision.CompareTag("Triangle"))
        {
            // Player chết khi chạm hình tam giác
            Destroy(gameObject);
            // Hiện màn hình Game Over
            GameOverManager.Instance.ShowGameOver();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Stairs"))
        {
            canClimb = false;
        }
    }

    private void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

            if (bullet.TryGetComponent(out Bullet bulletScript)) // Use TryGetComponent to avoid allocation
            {
                bulletScript.bulletDirection = sprite.flipX ? Vector2.left : Vector2.right; // Updated to use renamed property
            }
        }
    }
}
