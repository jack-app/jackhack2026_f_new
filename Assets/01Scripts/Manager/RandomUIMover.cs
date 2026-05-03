using UnityEngine;
using System.Collections; // コルーチンを使うために必要

public class RandomUIMover : MonoBehaviour
{
    // 移動のパラメータ
    [Header("Movement Settings")]
    public float moveSpeed = 100f;    // 移動速度（ピクセル/秒）
    public float waitTimeMin = 0.5f;  // 目標地点に着いた後の待ち時間（最小）
    public float waitTimeMax = 2.0f;  // 目標地点に着いた後の待ち時間（最大）

    // 移動範囲のパラメータ
    [Header("Range Settings")]
    // Canvasのサイズに対して、どれくらいの範囲を動くか（0.0〜1.0）
    // 例: 0.8なら、画面中央から上下左右に画面サイズの80%の範囲で動く
    [Range(0f, 1f)]
    public float moveRangePercent = 0.8f; 

    private RectTransform rectTransform;
    private RectTransform canvasRectTransform;
    private Vector2 targetPosition;
    private Vector2 moveRange;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        // 親のCanvasのRectTransformを取得して画面サイズを知る
        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas != null)
        {
            canvasRectTransform = canvas.GetComponent<RectTransform>();
        }
        else
        {
            Debug.LogError("Canvasの中にImageがありません！");
            enabled = false;
            return;
        }

        // 移動ロジック（コルーチン）を開始
        StartCoroutine(MovementRoutine());
    }

    // 移動のメインループ
    IEnumerator MovementRoutine()
    {
        while (true) // ずっと繰り返す
        {
            // 1. 新しい目標地点を決める
            SetNewTargetPosition();

            // 2. 目標地点に着くまで移動する
            while (Vector2.Distance(rectTransform.anchoredPosition, targetPosition) > 1f)
            {
                // Vector2.MoveTowardsを使って滑らかに近づける
                rectTransform.anchoredPosition = Vector2.MoveTowards(
                    rectTransform.anchoredPosition,
                    targetPosition,
                    moveSpeed * Time.deltaTime
                );
                yield return null; // 1フレーム待つ
            }

            // 3. 到着したらランダムな時間待つ
            float waitTime = Random.Range(waitTimeMin, waitTimeMax);
            yield return new WaitForSeconds(waitTime);
        }
    }

    // 画面サイズに基づき、ランダムな座標を計算する
    void SetNewTargetPosition()
    {
        // Canvasのサイズを取得
        Vector2 canvasSize = canvasRectTransform.sizeDelta;

        // アンカーが中央(0.5, 0.5)であることを前提とした移動範囲
        // 画面外にはみ出さないよう、自身のサイズ(rectTransform.rect.width/2)も考慮する
        float rangeX = (canvasSize.x * moveRangePercent / 2f) - (rectTransform.rect.width / 2f);
        float rangeY = (canvasSize.y * moveRangePercent / 2f) - (rectTransform.rect.height / 2f);

        // 範囲をマイナスにする（画像が画面より大きい場合など）のを防ぐ
        rangeX = Mathf.Max(rangeX, 0);
        rangeY = Mathf.Max(rangeY, 0);

        // ランダムな座標を生成
        float randomX = Random.Range(-rangeX, rangeX);
        float randomY = Random.Range(-rangeY, rangeY);

        targetPosition = new Vector2(randomX, randomY);
    }
}