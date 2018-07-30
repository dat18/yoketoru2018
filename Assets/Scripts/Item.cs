using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    [SerializeField]
    private int Point = 100;

    public static int Count
    {
        get;
        private set;
    }

    public static void ClearCount()
    {
        Count = 0;
    }

    private void Start()
    {
        Count++;
    }

    /// <summary>
    /// 拾われた時に呼び出すメソッド
    /// </summary>
    public void Pickup()
    {
        // 得点
        GameSystem.Instance.AddScore(Point);

        // 数を減らす
        Count--;

        // 自分を削除
        Destroy(gameObject);
    }

}
