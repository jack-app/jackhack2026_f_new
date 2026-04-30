using UnityEngine;

public class EnemyDamageBox : MonoBehaviour
{
    public int touchDamage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ぶつかった相手が IDamageable を持っているか取得
        IDamageable target = other.gameObject.GetComponent<IDamageable>();
        
        if (target != null)
        {
            target.TakeDamage(touchDamage);
        }
    }
}