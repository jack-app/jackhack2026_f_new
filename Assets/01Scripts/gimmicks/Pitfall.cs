using UnityEngine;

[RequireComponent(typeof(Collider2D))] 
public class Pitfall : MonoBehaviour
{
    [Header("落下ダメージ量")]
    public int fallDamage = 1;

    [Header("プレイヤーのスタート地点のオブジェクトを取り付けてください")]
    [Tooltip("リスポーン地点となります")]
    [SerializeField] private GameObject StartObject;

    private Vector3 RespownPoint;
    [SerializeField]private AudioClip SE1; 

    void Start()
    {
        if(StartObject!=null)
        {
            RespownPoint=StartObject.transform.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable target = collision.gameObject.GetComponent<IDamageable>();
            if (target != null)
            {
                target.TakeDamage(fallDamage);
            }
            PlaySE1();

            // ワープ
                collision.transform.position = RespownPoint;
            

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
    public void PlaySE1()
    {
        AudioManager.Instance.PlaySE(SE1, 0.5f);
    }
}