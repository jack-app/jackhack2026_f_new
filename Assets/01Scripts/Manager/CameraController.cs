using UnityEngine;

public class CameraController : MonoBehaviour
{
    //プレイヤーをインスペクタでとりつける
    //このオブジェクトにカメラが追尾する
    [SerializeField] private GameObject player;
    Vector3 presentpos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position != presentpos)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -20);
            presentpos = player.transform.position;
        }
    }
}
