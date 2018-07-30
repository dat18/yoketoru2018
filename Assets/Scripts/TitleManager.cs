using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update () {
        // クリックされたか？
        if (Input.GetMouseButtonDown(0))
        {
            SEManager.Instance.Play(SEManager.SE.CLICK);
            // Gameシーンを読み込む
            SceneManager.LoadScene("Game");
        }
    }
}
