using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    [Header("ステージ遷移先")]
    [Tooltip("移動先のシーン名")]
   [SerializeField] private string sceneName; // 移動先のシーン名
    [Tooltip("移動先のステージ名（もしあれば）(1～5)")]
   [SerializeField] private int Stagenumber=-1; // 移動先のステージナンバー
   public void ChangeScene()
   {
       SceneManager.LoadScene(sceneName);
   }
}