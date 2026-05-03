using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagervitamin21 : MonoBehaviour
{
    public GameObject menuPanel;

    public void OpenMenu()
    {
        menuPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void CloseMenu()
    {
        menuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToStgeSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("02StageSelect");
    }
}
