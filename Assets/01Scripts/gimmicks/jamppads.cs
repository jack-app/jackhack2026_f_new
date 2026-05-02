
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [Header("跳ね飛ばす力")]
    public float jumpPower = 15f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        if (rb == null) return;

        // Y方向の速度をリセットして、確実に跳ねさせる
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

        // 上方向に力を加える
        rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
}
