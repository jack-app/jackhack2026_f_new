using UnityEngine;
using UnityEngine.SceneManagement;

public class HuretaraSeni : MonoBehaviour
{
    [Header("ステージ遷移先")]
    [Tooltip("移動先のシーン名")]
   [SerializeField] private string sceneName; // 移動先のシーン名
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
   {
        GameStatusManager.Instance.runtimeStatus.ReNew();
       SceneManager.LoadScene(sceneName);
   }

   private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.CompareTag("Player"))
        {
            ChangeScene();
        }
    }
}
