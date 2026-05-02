using UnityEngine;

public class WindArea : MonoBehaviour
{
    [Header("風の強さ（上向きの速度）")]
    public float upwardSpeed = 5f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        Rigidbody2D rb = other.attachedRigidbody;
        if (rb == null) return;

        // 下向きに落下している場合、上向きの速度に書き換える
        if (rb.linearVelocity.y < upwardSpeed)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, upwardSpeed);
        }
    }
}
