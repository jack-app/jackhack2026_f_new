using UnityEngine;
using UnityEngine.InputSystem;

public class TimeChange : MonoBehaviour
{
    [Header("ゲームオブジェクト")]
    [Tooltip("過去のオブジェクト")]
    [SerializeField]private GameObject Past;
    [Tooltip("未来のオブジェクト")]
    [SerializeField]private GameObject Current;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //もし取得できていなかった場合
        if (Past == null)
        {
            Past=transform.Find("Past").gameObject;
        }
        if (Current == null)
        {
            Current=transform.Find("Current").gameObject;
        }
        //開始時に現在のオブジェクトを表示するように
        Past.SetActive(false);
        Current.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ChangeTime()を呼べば過去と未来を変更できます
    public void ChangeTime()
    {
        if (GameStatusManager.Instance.runtimeStatus.isCurrent == true)
        {
            //現在にいるなら
            Debug.Log("現在ー＞過去");
            //時間を止める
            GameStatusManager.Instance.runtimeStatus.SetPause();
            //何かエフェクト
            Current.SetActive(false);
            Past.SetActive(true);
            GameStatusManager.Instance.runtimeStatus.isCurrent=false;
            //時間を進める
            GameStatusManager.Instance.runtimeStatus.SetPause();

        }
        else
        {
            //過去にいるなら
            Debug.Log("過去ー＞現在");
            //時間を止める
            GameStatusManager.Instance.runtimeStatus.SetPause();
            //何かエフェクト
            Past.SetActive(false);
            Current.SetActive(true);
            GameStatusManager.Instance.runtimeStatus.isCurrent=true;
            //時間を進める
            GameStatusManager.Instance.runtimeStatus.SetPause();
        }
    }

    public void OnDebug(InputAction.CallbackContext context)
    {
        if (!context.started) 
    {
        return; 
    }
        //デバック用
            ChangeTime();
            Debug.Log("Pressed M");

    }
}
