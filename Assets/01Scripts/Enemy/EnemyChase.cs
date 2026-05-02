using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [Header("ステータス")]
    [SerializeField] private float speed = 3f;           // 敵の移動速度
    [SerializeField] private float detectionRange = 5f;  // プレイヤーを発見する距離（半径）
    [SerializeField] private float jumpForce = 5f;       // ジャンプ力（追加）

    [SerializeField] private GameObject Players;
    private Vector3 currentpos;
    private Rigidbody2D rb;
    private float ximg,yimg,zimg;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        
        // シーン内から "Players" という名前のオブジェクトを探して設定
        if (Players == null)
        {
            Players = GameObject.Find("Players");
        }
        ximg = Mathf.Abs(transform.localScale.x);
        yimg = transform.localScale.y;
        zimg = transform.localScale.z;
    }

    void FixedUpdate()
    {

        if (Players != null)
        {

            float distance = Vector2.Distance(transform.position, Players.transform.position);

            if (distance <= detectionRange)
            {
                ChasePlayer();

                // 【ジャンプ処理】
 
                if (Mathf.Abs(currentpos.x - transform.position.x) < 0.01f)
                {
                  
                    if (Mathf.Abs(rb.linearVelocity.y) < 0.01f)
                    {
                        Jump();
                    }
                }
            }
            else
            {
                // 発見範囲外に出たらピタッと止まるようにする
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }
        }
        
        // 現在の位置を次フレームの比較用に保存
        currentpos = transform.position;
    }

    void ChasePlayer()
    {

        float direction = Mathf.Sign(Players.transform.position.x - transform.position.x);


        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);

        // （おまけ）敵の画像を進行方向に向かせる
        transform.localScale = new Vector3(direction > 0 ? ximg : -ximg, yimg, zimg);
    }

    void Jump()
    {
        // 上に向かってジャンプ力を加える
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    // （おまけ）シーンビューで発見範囲の円を視覚的に確認するための処理
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}