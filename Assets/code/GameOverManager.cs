using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOverManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        if (gameOverUI != null)
            gameOverUI.SetActive(false);
    }

    public void ShowGameOver()
    {
        if (gameOverUI != null)
            gameOverUI.SetActive(true);
        Time.timeScale = 0f; // Dừng game
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Đổi tên scene nếu cần
    }

    public void TriggerGameOver()
    {
        GameOverManager.Instance.ShowGameOver();
        Destroy(gameObject);
    }
}
