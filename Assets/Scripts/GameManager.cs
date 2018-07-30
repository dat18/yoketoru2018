using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        GameSystem.Instance.ClearScore();
        GameSystem.IsPlaying = true;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update () {
        if (!GameSystem.IsPlaying) return;

        // Oキーが押されたか判定
        if (Input.GetKeyDown(KeyCode.O))
        {
            // マルチシーンで、GameOverシーンを読み込む方法
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        }
	}

    public void StopBGM()
    {
        GetComponent<AudioSource>().Stop();
    }
}
