using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalPost : MonoBehaviour
{
    [SerializeField] private SceneChanger sceneChanger;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("ゴール！");
            ClearLevel();
        }
    }

    void ClearLevel()
    {
        sceneChanger.ChangeScene();
    }
}