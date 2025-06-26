using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    public GameObject victoryUI;

    public static VictoryManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        if (victoryUI != null)
            victoryUI.SetActive(false);
    }

    public void ShowVictory()
    {
        if (victoryUI != null)
            victoryUI.SetActive(true);
        Time.timeScale = 0f; // D?ng game
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1"); // ??i "Level1" thành tên scene level 1 c?a b?n
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // ??i tên scene n?u c?n
    }
}