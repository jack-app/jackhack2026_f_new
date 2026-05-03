using UnityEngine;

public class SquareColorChanger : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("色設定")]
    public Color currentColor = Color.blue;
    public Color pastColor = Color.red;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // TimeChange の状態を監視するだけ
        bool isCurrent = GameStatusManager.Instance.runtimeStatus.isCurrent;

        if (isCurrent)
        {
            sr.color = currentColor;
        }
        else
        {
            sr.color = pastColor;
        }
    }
}
