using UnityEngine;

public class StageSelectUIController : MonoBehaviour
{
    [Header("クリア状況に応じて表示したいUI")]
    [SerializeField] private GameObject stage1ClearBadge; // 「Clear!」などの画像
    [SerializeField] private GameObject stage2Button;     // ステージ2へのボタン
    [SerializeField] private GameObject warp2;     // ステージ2へのワープ
    [SerializeField] private GameObject stage2ClearBadge; // 「Clear!」などの画像
    [SerializeField] private GameObject stage3Button;     // ステージ2へのボタン
    [SerializeField] private GameObject warp3;     // ステージ3へのワープ
    [SerializeField] private GameObject stage3ClearBadge; // 「Clear!」などの画像

    void Start()
    {
        // マネージャーから現在のステータスを取得
        var status = GameStatusManager.Instance.runtimeStatus;

        // ステージ1がクリアされていたら
        if (status.stage1)
        {
            if (stage1ClearBadge != null) stage1ClearBadge.SetActive(true);
            if (stage2Button != null) stage2Button.SetActive(true);
            if (warp2 != null) warp2.SetActive(true);
        }
        else
        {
            if (stage1ClearBadge != null) stage1ClearBadge.SetActive(false);
            if (stage2Button != null) stage2Button.SetActive(false);
             if (warp2 != null) warp2.SetActive(false);
        }

        if (status.stage2)
        {
            if (stage2ClearBadge != null) stage2ClearBadge.SetActive(true);
            if (stage3Button != null) stage3Button.SetActive(true);
            if (warp3 != null) warp3.SetActive(true);
        }
        else
        {
            if (stage2ClearBadge != null) stage2ClearBadge.SetActive(false);
            if (stage3Button != null) stage3Button.SetActive(false);
            if (warp3 != null) warp3.SetActive(false);
        }

        if (status.stage3)
        {
            if (stage3ClearBadge != null) stage3ClearBadge.SetActive(true);
        }
        else
        {
            if (stage3ClearBadge != null) stage3ClearBadge.SetActive(false);
        }
    }
}