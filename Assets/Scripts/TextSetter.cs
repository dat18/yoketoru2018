using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextSetter : MonoBehaviour {

    private void Start()
    {
        // 自分のオブジェクトにアタッチされている
        // TextMeshPro UGUIのインスタンス(操作するためのアドレス)を取得する
        TextMeshProUGUI tmp = GetComponent<TextMeshProUGUI>();

        // 取得したUGUIのインスタンスを、GameSystemに渡す
        GameSystem.Instance.SetScoreText(tmp);
    }
}
