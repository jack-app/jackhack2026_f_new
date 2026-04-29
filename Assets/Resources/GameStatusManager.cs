using UnityEngine;

public class GameStatusManager : MonoBehaviour
{
    // どこからでも「GameStatusManager.Instance」でアクセスできるようにする
    public static GameStatusManager Instance { get; private set; }

    [Header("プロジェクト内のマスターデータ（.asset）")]
    [SerializeField] private GameStatus baseStatusAsset;

    // 他のクラスから読み書きする用のクローン
    public GameStatus runtimeStatus { get; private set; }

    // ゲーム開始時に自動で実行されるメソッド
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void InitializeAndSpawn()
    {
        if (Instance == null)
        {
            // プロジェクトのResourcesフォルダなどからアセットをロード
            var baseAsset = Resources.Load<GameStatus>("GameStatus");

            // マネージャーを生成
            GameObject go = new GameObject("GameStatusManager");
            Instance = go.AddComponent<GameStatusManager>();
            Instance.baseStatusAsset = baseAsset;

            //シーンを跨いでも壊れないようにする
            DontDestroyOnLoad(go);

            // データのクローン（分身）を作成
            Instance.runtimeStatus = Instantiate(baseAsset);
        }
    }
}