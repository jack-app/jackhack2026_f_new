using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    private int currentHP=1;
    private PlayerManager playerManager;
    void Start()
    {
         currentHP = GameStatusManager.Instance.runtimeStatus.health;
         playerManager=GetComponent<PlayerManager>();
    }
    
    // インターフェースのメソッドを実装
    public void TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;
        Debug.Log($"プレイヤーは {damageAmount} のダメージを受けた！ 残りHP: {currentHP}");

        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("プレイヤー死亡");
        if (GameStatusManager.Instance.runtimeStatus.life > 0)
        {
            GameStatusManager.Instance.runtimeStatus.life-=1;
            Debug.Log($"プレイヤーのライフ{GameStatusManager.Instance.runtimeStatus.life}");
        }
        else
        {
            Debug.Log($"プレイヤーのライフ{GameStatusManager.Instance.runtimeStatus.life}");
            //ゲームオーバー処理を行う
        }
        currentHP = GameStatusManager.Instance.runtimeStatus.health;
        playerManager.Respown();
        
    }
}