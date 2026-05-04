using UnityEngine;

public class BGMStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     [SerializeField]private AudioClip BGM1;
    void Start()
    {
        StopMusic();
        AudioManager.Instance.PlayBGM(BGM1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StopMusic()
    {
        AudioManager.Instance.StopBGM();
    }
}
