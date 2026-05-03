
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
            isClear = true;
            stageClearPanel.SetActive(true);
        }
    }
}
