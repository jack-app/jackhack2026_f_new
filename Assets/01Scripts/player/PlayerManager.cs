using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [Header("地面の接地判定に利用")]
    [Tooltip("地面の接地判定に利用")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("プレイヤーのスタート地点のオブジェクトを取り付けてください")]
    [Tooltip("リスポーン地点となります")]
    [SerializeField] private GameObject StartObject;
    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool jumppressed=false;
    private bool isGrounded;
    private float jumpForce;

    private Vector3 RespownPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed=GameStatusManager.Instance.runtimeStatus.speed;
        jumpForce=GameStatusManager.Instance.runtimeStatus.jumpForce;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        RespownPoint=StartObject.transform.position;
    }

    
    public void OnMove(InputAction.CallbackContext context)
    {
        // 入力値を Vector2 (x, y) として受け取る
        moveInput = context.ReadValue<Vector2>();
        
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        //Debug.Log("押された");
        if (context.started)
        {
            jumppressed =true;
        }
        
    }

    void Update()
    {
         isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.3f, groundLayer);
         
    }

    void FixedUpdate()
    {
       rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
        
        if (jumppressed && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // 上方向速度を一度リセット
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        jumppressed = false; // 入力をリセット
    }

     private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.3f);
        }
    }
    public void Respown()
    {
        transform.position=RespownPoint;
        
    }
}