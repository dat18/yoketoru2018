using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour {

    public enum SE
    {
        CLICK,  // クリック音
        EAT,    // アイテム取得
        MISS,   // 敵にぶつかった
        BOUND,  // 敵が壁で跳ね返る
    }

    [SerializeField]
    private AudioClip[] seList;

    public static SEManager Instance;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void Play(SE se)
    {
        audioSource.PlayOneShot(seList[(int)se]);
    }

}
