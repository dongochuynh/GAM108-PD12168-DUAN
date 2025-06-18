using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwim : MonoBehaviour
{
    // C�c bi?n ?i?u khi?n
    public float swimSpeed = 5f; // T?c ?? b?i
    public float rotationSpeed = 100f; // T?c ?? xoay
    private Rigidbody2D rb2d; // Rigidbody2D c?a Player
    private Vector2 movement; // Vector di chuy?n

    void Start()
    {
        // L?y Rigidbody2D
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Nh?n ??u v�o t? ng??i ch?i
        float moveX = Input.GetAxis("Horizontal"); // Di chuy?n tr�i ph?i (ph�m A/D ho?c m?i t�n tr�i/ph?i)
        float moveY = Input.GetAxis("Vertical"); // Di chuy?n l�n xu?ng (ph�m W/S ho?c m?i t�n l�n/xu?ng)

        // T?o vector di chuy?n
        movement = new Vector2(moveX, moveY).normalized;

        // Xoay Player theo h??ng di chuy?n
        if (movement.sqrMagnitude > 0)
        {
            float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg; // T�nh g�c xoay
            rb2d.rotation = Mathf.LerpAngle(rb2d.rotation, angle, Time.deltaTime * rotationSpeed); // Xoay Player v? h??ng di chuy?n
        }
    }

    void FixedUpdate()
    {
        // �p d?ng l?c di chuy?n v�o Rigidbody2D c?a Player
        rb2d.linearVelocity = movement * swimSpeed; // Th�m v?n t?c cho Player ?? b?i
    }
}
