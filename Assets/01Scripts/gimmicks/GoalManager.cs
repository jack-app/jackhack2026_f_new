using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPost : MonoBehaviour
{
    [SerializeField] private SceneChanger sceneChanger;
     [Header("現在のステージ")]
      [Tooltip("ゴールフラグを付けるよう")]
    [SerializeField] private int stage=0;

    void Start()
    {
        GameStatusManager.Instance.runtimeStatus.currentStageIndex=stage;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("ゴール！");
            ClearLevel();
        }
    }

    void ClearLevel()
    {
        if(GameStatusManager.Instance.runtimeStatus.maxReachedStage>stage)
        {
            GameStatusManager.Instance.runtimeStatus.maxReachedStage=stage;
        }
        sceneChanger.ChangeScene();
    }
}