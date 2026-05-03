using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    public float flowSpeed = 3f;   // 押し流す速度
    private Rigidbody2D playerRb;
    private bool playerInWater = false;

    void Update()
    {
        if (playerInWater && playerRb != null)
        {
            // プレイヤーを右方向に押し流す
            playerRb.AddForce(new Vector2(flowSpeed, 0), ForceMode2D.Force);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerRb = collision.GetComponent<Rigidbody2D>();
            playerInWater = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInWater = false;
            playerRb = null;
        }
    }
}
