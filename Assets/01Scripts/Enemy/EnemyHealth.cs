using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private  int currentHP=1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damageAmount)
    {
        currentHP -= damageAmount;
        Debug.Log($"プレイヤーは {damageAmount} のダメージを受けた！ 残りHP: {currentHP}");

        if (currentHP <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
