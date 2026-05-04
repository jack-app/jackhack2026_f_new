using UnityEngine;
using System.Collections;

public class Oto : MonoBehaviour
{
    [SerializeField]private AudioClip SE1; 
    [SerializeField]private AudioClip SE2; 
    [SerializeField]private AudioClip stageBGM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AudioManager.Instance.StopBGM();
        AudioManager.Instance.PlaySE(SE1);
        StartCoroutine(DelayCoroutine());
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator DelayCoroutine()
    {
        // 3秒間待つ
        yield return new WaitForSeconds(2);
        AudioManager.Instance.PlaySE(SE2);
        yield return new WaitForSeconds(2);
        AudioManager.Instance.PlayBGM(stageBGM, 0.5f);

    }
}
