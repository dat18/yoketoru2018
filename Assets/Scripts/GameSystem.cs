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
}
