
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClearUI : MonoBehaviour
{
    [SerializeField] private string NextStage;
    public void GoToSelect()
    {
        GameStatusManager.Instance.runtimeStatus.ReNew();
        //ステージセレクトへ
        SceneManager.LoadScene("02StageSelect");
    }

    public void GoToNextStage()
    {
        GameStatusManager.Instance.runtimeStatus.ReNew();
        SceneManager.LoadScene(NextStage);
    }
}
