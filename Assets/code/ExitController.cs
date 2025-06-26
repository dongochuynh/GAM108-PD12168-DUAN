using UnityEngine;

public class ExitController : MonoBehaviour
{
    private bool isOpen = false;

    public void SetExitOpen(bool open)
    {
        isOpen = open;
        // Có thể đổi sprite hoặc hiệu ứng ở đây nếu muốn
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen && collision.CompareTag("Player"))
        {
            // Qua màn, ví dụ load scene mới
            // SceneManager.LoadScene("NextLevel");
            Debug.Log("Level Complete!");
        }
    }
}