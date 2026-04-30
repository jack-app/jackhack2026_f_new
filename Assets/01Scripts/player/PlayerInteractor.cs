using UnityEngine;
using UnityEngine.InputSystem; 

public class PlayerInteractor : MonoBehaviour
{
    // 現在触れる範囲にあるオブジェクトを記憶する箱
    private IInteractable currentInteractable;

    void Update()
    {
        if (currentInteractable as UnityEngine.Object == null)
        {
            currentInteractable = null;
        }

        // もし記憶しているオブジェクトがある
        if (currentInteractable != null )
        {
            // アイテム側の処理を実行する！
            currentInteractable.Interact();
        }
    }

    // 見えない枠（Trigger）に入った時
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ぶつかった相手が IInteractable を持っているかチェック
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            // 持っていたら記憶する
            currentInteractable = interactable;
            Debug.Log("アイテムに近づいた！（UIを表示するなどの処理をここに書く）");
        }
    }

    // 見えない枠（Trigger）から出た時
    private void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            // 記憶をリセットする
            currentInteractable = null;
            Debug.Log("アイテムから離れた（UIを消すなどの処理）");
        }
    }
}