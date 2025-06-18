using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;

    public float movespeed = 2f;
    public float jumpForce = 3f;

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
        if (Mathf.Abs(moveInput) > 0.01f)  // Nếu có chuyển động
        {
            animator.SetBool("isRunning", true);  // Kích hoạt trạng thái chạy
        }
        else
        {
            animator.SetBool("isRunning", false);  // Tắt trạng thái chạy khi không di chuyển
        }

        // Quay nhân vật qua lại (lật hình ảnh của nhân vật)
        if (moveInput > 0)
        {
            sprite.flipX = false;  // Quay mặt nhân vật sang phải
        }
        else if (moveInput < 0)
        {
            sprite.flipX = true;   // Quay mặt nhân vật sang trái
        }

        // Xử lý nhảy (phím Space)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);  // Áp dụng lực nhảy
            animator.SetTrigger("doJump");  // Kích hoạt trigger nhảy
        }

        // Xử lý lăn (phím Shift trái/phải)
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && Mathf.Abs(moveInput) > 0.1f)
        {
            animator.SetTrigger("doRoll");  // Kích hoạt trigger lăn
            animator.SetBool("isRunning", false);  // Tắt trạng thái chạy khi lăn
        }

        // Xử lý leo (phím F)
        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("isEscalate");
        }

        // Xử lý trạng thái lo lắng (phím G)
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetTrigger("isWorried");
        }
    }
}
