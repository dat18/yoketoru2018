using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //score = 0;
	}

	// Update is called once per frame
	void Update () {
        // Oキーが押されたか判定
        if (Input.GetKeyDown(KeyCode.O))
        {
            // マルチシーンで、GameOverシーンを読み込む方法
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        }
	}
}
