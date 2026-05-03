using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.Mathematics;

public class PlayerManager : MonoBehaviour
{
    [Header("地面の接地判定に利用")]
    [Tooltip("地面の接地判定に利用")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("プレイヤーのスタート地点のオブジェクトを取り付けてください")]
    [Tooltip("リスポーン地点となります")]
    [SerializeField] private GameObject StartObject;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool jumppressed=false;
    private bool isGrounded;
    public bool isWalking=false;
    private float jumpForce;
    [SerializeField] SpriteRenderer spriteRenderer;

    private Vector3 RespownPoint;
    [SerializeField] PlayerAnimation playerAnimation;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed=GameStatusManager.Instance.runtimeStatus.speed;
        jumpForce=GameStatusManager.Instance.runtimeStatus.jumpForce;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        if(StartObject!=null)
        {
            RespownPoint=StartObject.transform.position;
        }
        if(playerAnimation==null)
        {
            playerAnimation=GetComponentInChildren<PlayerAnimation>();
        }
        if(spriteRenderer==null)
        {
            spriteRenderer=GetComponentInChildren<SpriteRenderer>();
        }
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
            playerAnimation.JumpAnim();
        }
        
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.started) 
    {
        return; 
    }
        //デバック用
            GameStatusManager.Instance.runtimeStatus.SetPause();
            Debug.Log("Pressed E");

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
        if(math.abs(moveInput.x) > 0.1)
        {
            isWalking=true;
        }
        else
        {
            isWalking=false;
        }

        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput.x < 0)
        {
            spriteRenderer.flipX = false;
        }
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
         moveSpeed=GameStatusManager.Instance.runtimeStatus.speed;
        
    }

    public void resetSpeed()
    {
        StartCoroutine(DelayCoroutine());
    }


     private IEnumerator DelayCoroutine()
    {
        // 3秒間待つ
        yield return new WaitForSeconds(3);
        Debug.Log("3秒後の処理");
        moveSpeed=GameStatusManager.Instance.runtimeStatus.speed;

    }
}