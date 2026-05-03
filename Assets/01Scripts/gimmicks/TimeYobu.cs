using UnityEngine;

public class TimeYobu: MonoBehaviour
{
    [Tooltip("TimeChange を持つオブジェクト")]
    [SerializeField]private TimeChange timeChanger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Rigidbody2D rb = collision.attachedRigidbody;
        if (rb == null) return;


        timeChanger.ChangeTime();
        
    }
}
