using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    //インスペクタから取り付ける
    [SerializeField]private AudioClip SE1; 
    [SerializeField]private AudioClip SE2;
    [SerializeField]private AudioClip SE3;  
    [SerializeField]private AudioClip BGM1;
    [SerializeField]private AudioClip BGM2;
    

    //外部から以下のメソッドを呼び出せば音を流したり、止めたりできます

    //外部から参照するときはできる限り[SerializeField]で参照してください
    //そっちの方がゲームの処理的に軽い
    public void PlayBGM1()
    {
        AudioManager.Instance.PlayBGM(BGM1, 0.5f);
    }
    public void PlayBGM2()
    {
        AudioManager.Instance.PlayBGM(BGM2, 0.5f);
    }
    public void PlaySE1()
    {
        AudioManager.Instance.PlayBGM(SE1, 0.5f);
    }
    public void PlaySE2()
    {
        AudioManager.Instance.PlayBGM(SE2, 0.5f);
    }
    public void PlaySE3()
    {
        AudioManager.Instance.PlayBGM(SE3, 0.5f);
    }
    public void StopMusic()
    {
        AudioManager.Instance.StopBGM();
    }

}
