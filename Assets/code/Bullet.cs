namespace GameNamespace // Added a namespace to avoid conflicts
{
    using UnityEngine;

    public class Bullet : MonoBehaviour
    {
        public float speed = 10f;
        public float lifeTime = 2f;
        public Vector2 direction = Vector2.right; // Nên gán giá trị mặc định

        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            Destroy(gameObject, lifeTime);
        }

        private void Update() // Changed from FixedUpdate to Update
        {
            rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                Destroy(collision.gameObject); // Enemy chết
                Destroy(gameObject); // Đạn biến mất
            }
            else if (!collision.CompareTag("Player") && !collision.CompareTag("Coin"))
            {
                Destroy(gameObject); // Đạn biến mất khi trúng vật khác
            }
        }
    }
}
