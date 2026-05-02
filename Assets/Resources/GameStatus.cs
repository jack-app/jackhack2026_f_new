using UnityEngine;

[CreateAssetMenu(fileName = "GameStatus", menuName = "GameData/GameStatus")]
public class GameStatus : ScriptableObject
{
    [Header("インスペクタでの変更禁止")]

    [Header("ステージ進行度")]
    [Tooltip("現在プレイ中のステージ番号（例：1からスタート）")]
    public int currentStageIndex = 1;
    
    [Tooltip("これまでにクリア・到達した最大ステージ番号（アンロック判定などに使用）")]
    public int maxReachedStage = 1;

    [Header("スコア情報")]
    [Tooltip("今回のプレイでの現在のスコア")]
    public int currentScore = 0;
    
    [Tooltip("これまでの最高スコア（ハイスコア）")]
    public int highScore = 0;

    [Header("時間が流れているか")]
    [Tooltip("True:止まっている/False:動いている")]
    public bool isPaused =false;

    //今後使いそうなものを入れておく
    [Header("キャラクターのステータス関連")]
    [Tooltip("現在のレベル")]
    public int currentLevel = 1;

    [Tooltip("スピード")]
    public float speed = 5f;
    [Tooltip("ジャンプ")]
    public float jumpForce = 5f;

    [Tooltip("ライフ")]
    public int life = 5;
    [Tooltip("ヘルス")]
    public int health = 3;

    [Header("収集物")]
    [Tooltip("コイン")]
    public int coins = 0;
    [Tooltip("トータルコイン")]
    public int totalcoins = 0;
    [Header("時間")]
    [Tooltip("現在:True , 過去:False")]
    public bool isCurrent = true;

    /// <summary>
    /// ゲーム開始時やタイトルから始めた時に、今回のプレイデータをリセットする
    /// （ハイスコアや最大到達ステージなど、引き継ぐデータはリセットしない）
    /// </summary>
    public void ResetForNewPlay()
    {
        currentStageIndex = 1;
        maxReachedStage = 1;
        currentScore = 0;
        highScore = 0;
        currentLevel = 1;
        speed = 5f;
        jumpForce = 5f;
        life = 5;
        coins=0;
        totalcoins=0;
        health = 3;
        isPaused =false;
        isCurrent = true;
    }

    //簡易リセット用（ステージ入るときとかに利用推奨）
    public void ReNew()
    {
        health = 3;
        speed = 5f;
        jumpForce = 5f;
        isPaused =false;
        isCurrent = true;
    }

    /// <summary>
    /// スコアを加算し、同時にハイスコアの更新判定も行う
    /// </summary>
    /// <param name="amount">加算するスコア量</param>
    public void AddScore(int amount)
    {
        currentScore += amount;
        
        // ハイスコアを上回ったら更新
        if (currentScore > highScore)
        {
            highScore = currentScore;
        }
    }

    //コイン
    public void CoinToLife(int amounts)
    {   
        // 100コインで1つライフ獲得
        if (amounts >= 100)
        {
            life+=1;
            coins-=100;
        }
    }

    //時間停止用
    public void SetPause()
    {
       
        if (!isPaused)
        {
            Time.timeScale = 0f;
            isPaused=true;
            AudioListener.pause = true; // または MixerでBGMを下げる
             Debug.Log("時間停止");
        }
        else
        {
            Time.timeScale = 1f;
            isPaused=false;
            AudioListener.pause = false;
            Debug.Log("時間うごきだし");
        }
    }
}