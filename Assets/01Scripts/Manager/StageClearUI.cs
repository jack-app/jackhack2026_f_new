
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClearUI : MonoBehaviour
{
    [SerializeField] private string NextStage;
    public void GoToSelect()
    {
        SceneManager.LoadScene("Select");
    }

    public void GoToNextStage()
    {
        SceneManager.LoadScene(NextStage);
    }
}
