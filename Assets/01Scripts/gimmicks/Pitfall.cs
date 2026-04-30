using UnityEngine;

[RequireComponent(typeof(Collider2D))] 
public class Pitfall : MonoBehaviour
{
    [Header("落下ダメージ量")]
    public int fallDamage = 1;

    [Header("プレイヤーのスタート地点のオブジェクトを取り付ける")]
    [Tooltip("リスポーン地点になる")]
    [SerializeField] private Transform respawnPoint; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable target = collision.gameObject.GetComponent<IDamageable>();
            if (target != null)
            {
                target.TakeDamage(fallDamage);
            }

            // ワープ
            collision.transform.position = respawnPoint.position;

            //速度0に
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero; 
            }
        }
    }

    private void OnDrawGizmos()
    {
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            Bounds bounds = col.bounds;
            Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.3f);
            Gizmos.DrawCube(bounds.center, bounds.size);
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
    }
}