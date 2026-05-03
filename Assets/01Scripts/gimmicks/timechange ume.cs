using UnityEngine;

public class SwitchTimeChanger : MonoBehaviour
{
    [Tooltip("TimeChange を持つオブジェクト")]
    public TimeChange timeChanger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        // プレイヤーの Rigidbody を取得
        Rigidbody2D rb = collision.attachedRigidbody;
        if (rb == null) return;

        // プレイヤーが下から上にぶつかったか判定
        // → 上方向の速度が正なら「下から叩いた」
        if (rb.linearVelocity.y > 0f)
        {
            Debug.Log("スイッチを下から叩いた！");
            timeChanger.ChangeTime();
        }
    }
}
