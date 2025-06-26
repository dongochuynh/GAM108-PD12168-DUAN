using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingPanel;

    public void PlayGame()
    {
        Time.timeScale = 1f; // Đảm bảo game không bị pause
        SceneManager.LoadScene(1); // Chuyển tới scene index 1
    }

    public void OpenSetting()
    {
        if (settingPanel != null)
        {
            settingPanel.SetActive(true);
            mainMenuPanel.SetActive(false);
        }
    }

    public void CloseSetting()
    {
        if (settingPanel != null)
        {
            settingPanel.SetActive(false);
            mainMenuPanel.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
