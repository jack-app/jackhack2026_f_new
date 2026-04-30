using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    [Header("ステージ遷移先")]
    [Tooltip("移動先のシーン名")]
   [SerializeField] private string sceneName; // 移動先のシーン名
   public void ChangeScene()
   {
       SceneManager.LoadScene(sceneName);
   }
}