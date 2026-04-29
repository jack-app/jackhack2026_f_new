using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    public string itemName = "ポーション";

    // インターフェースのルールに従ってInteractの中身を書く
    public void Interact()
    {
        Debug.Log(itemName + " を拾った！");
        
        // ここにアイテムをインベントリに入れる処理などを書く
        
        // 拾ったのでこのオブジェクトを消す
        Destroy(gameObject); 
    }
}