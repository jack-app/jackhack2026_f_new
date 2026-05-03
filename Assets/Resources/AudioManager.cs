using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // どこからでも「AudioManager.Instance」でアクセスできるようにする
    public static AudioManager Instance { get; private set; }

    // プログラムから自動で追加するAudioSource
    private AudioSource bgmSource;
    private AudioSource seSource;

    // ゲーム開始時（シーン読み込み前）に自動で実行されるメソッド
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize()
    {
        if (Instance == null)
        {
            // 1. マネージャー用オブジェクトを生成
            GameObject go = new GameObject("AudioManager");
            Instance = go.AddComponent<AudioManager>();

            // 2. スクリプトからAudioSourceを2つ追加（ヒエラルキーでの手作業不要！）
            Instance.bgmSource = go.AddComponent<AudioSource>();
            Instance.seSource = go.AddComponent<AudioSource>();

            // BGM用はループするように設定
            Instance.bgmSource.loop = true;

            // 3. シーンを跨いでも壊れないようにする
            DontDestroyOnLoad(go);
        }
    }

    /// <summary>
    /// BGMを再生する
    /// </summary>
    public void PlayBGM(AudioClip clip, float volume = 1.0f)
    {
        if (clip == null) return;

        // 同じ曲がすでに流れている場合は最初から再生し直さない
        if (bgmSource.clip == clip && bgmSource.isPlaying) return;

        bgmSource.clip = clip;
        bgmSource.volume = volume;
        bgmSource.Play();
    }

    /// <summary>
    /// BGMを停止する
    /// </summary>
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    /// <summary>
    /// SEを再生する
    /// </summary>
    public void PlaySE(AudioClip clip, float volume = 1.0f)
    {
        if (clip == null) return;

        seSource.PlayOneShot(clip, volume);
    }
}