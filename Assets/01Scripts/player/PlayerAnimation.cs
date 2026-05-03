using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Vector3 originalScale;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] PlayerManager playerManager;

    void Start()
    {
        // 元の大きさを保存しておく
        originalScale = transform.localScale;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if (playerManager == null)
        {
            playerManager=GetComponentInParent<PlayerManager>();
        }
    }

    void Update()
    {

       animator.SetBool("isWalking", playerManager.isWalking);
    }

    public void JumpAnim()
    {
        StartCoroutine(JumpAnimation());
    }

    public void DamageAnim()
    {
        StartCoroutine(DamageAnimation());
    }

    // ==========================================
    // ① ジャンプ時の伸び縮み（Squash & Stretch）
    // ==========================================
    private IEnumerator JumpAnimation()
    {
        // 1. 沈み込む（縦に潰れ、横に広がる）
        transform.localScale = new Vector3(originalScale.x * 1.3f, originalScale.y * 0.7f, originalScale.z);
        yield return new WaitForSeconds(0.1f);

        // 2. 飛び上がる（縦に伸び、横に細くなる）
        transform.localScale = new Vector3(originalScale.x * 0.8f, originalScale.y * 1.2f, originalScale.z);
        yield return new WaitForSeconds(0.15f);

        // 3. 空中で元のサイズに戻る
        transform.localScale = originalScale;
        yield return new WaitForSeconds(0.2f); // 空中にいる時間を想定

        // 4. 着地して少し潰れる
        transform.localScale = new Vector3(originalScale.x * 1.2f, originalScale.y * 0.8f, originalScale.z);
        yield return new WaitForSeconds(0.1f);

        // 5. 完全に元に戻る
        transform.localScale = originalScale;
    }

    // ==========================================
    // ② ダメージ時の揺れと赤点滅
    // ==========================================
    private IEnumerator DamageAnimation()
    {
        Vector3 originalPosition = transform.localPosition;
        
        // 色を赤にする
        spriteRenderer.color = Color.red;

        // 0.2秒間、左右にブルブル震える
        float elapsed = 0f;
        while (elapsed < 0.2f)
        {
            float xOffset = Random.Range(-0.1f, 0.1f); // 揺れの幅
            transform.localPosition = new Vector3(originalPosition.x + xOffset, originalPosition.y, originalPosition.z);
            elapsed += Time.deltaTime;
            yield return null; // 1フレーム待つ
        }

        // 位置と色を元に戻す
        transform.localPosition = originalPosition;
        spriteRenderer.color = Color.white;
    }
}