using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSystem : Singleton<GameSystem> {

    [SerializeField]
    TextMeshProUGUI scoreText;

    int score;

    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {
        // Aキーが押されたら点数を入れる
        if (Input.GetKey(KeyCode.A))
        {
            score += 10;
            updateScore();
        }
    }

    public void SetScoreText(TextMeshProUGUI txt)
    {
        scoreText = txt;
        updateScore();
    }

    void updateScore()
    {
        scoreText.text = score.ToString("D7");
    }

    /// <summary>
    /// スコアを0にする
    /// </summary>
    public void ClearScore()
    {
        score = 0;
        updateScore();
    }

    /// <summary>
    /// スコアを足す。カウンターストップの機能付き。
    /// </summary>
    /// <param name="add">得点</param>
    public void AddScore(int add)
    {
        score += add;
        if (score > 9999999)
        {
            score = 9999999;
        }
        updateScore();
    }

}
