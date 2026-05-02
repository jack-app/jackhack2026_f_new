using UnityEngine;
using TMPro;

public class zankiHyouji : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshPro;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text=$"x{GameStatusManager.Instance.runtimeStatus.life}";
        
    }
}
