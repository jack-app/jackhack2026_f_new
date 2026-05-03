
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameObject stageClearPanel;
    [Header("現在のステージ")]
    [Tooltip("ゴールフラグを付けるよう")]
    [SerializeField] private int stage=0;

    private bool isClear = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isClear) return;

        if (collision.CompareTag("Player"))
        {
            if(GameStatusManager.Instance.runtimeStatus.maxReachedStage>stage)
            {
                GameStatusManager.Instance.runtimeStatus.maxReachedStage=stage;
            }
            
            var status = GameStatusManager.Instance.runtimeStatus;

            switch (stage)
            {
                case 1: status.stage1 = true; break;
                case 2: status.stage2 = true; break;
                case 3: status.stage3 = true; break;
                case 4: status.stage4 = true; break;
                case 5: status.stage4 = true; break;
                default:
                Debug.Log($"存在しないステージ番号です: {stage}");
                break;
    }

            GameStatusManager.Instance.runtimeStatus.SetPause();
            isClear = true;
            stageClearPanel.SetActive(true);
        }
    }
}
