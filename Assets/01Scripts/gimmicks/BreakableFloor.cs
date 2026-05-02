using UnityEngine;

public class BreakableFloor : MonoBehaviour
{
    public float breakVelocityThreshold = -3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.CompareTag("Player")) return;

        Rigidbody2D rb = collision.collider.attachedRigidbody;
        if (rb == null) return;

        // Unity が保持している「衝突直前の速度」を使う
        Vector2 preVelocity = collision.relativeVelocity;

        // プレイヤーが床より上にいるかどうかで判定
        bool hitFromAbove = collision.transform.position.y > transform.position.y;

        Debug.Log("落下速度: " + preVelocity.y);
        Debug.Log("上から踏んだ？: " + hitFromAbove);

        if (hitFromAbove && preVelocity.y < breakVelocityThreshold)
        {
            Debug.Log("床が壊れました！");
            Destroy(gameObject);
        }
    }
}