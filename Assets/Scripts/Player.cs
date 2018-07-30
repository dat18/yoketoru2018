using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    Rigidbody rb;

    [SerializeField]
    private GameObject prefMiss;
    [SerializeField]
    private GameObject prefItem;

    [SerializeField]
    private float Speed = 10f;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
        // プレイ中じゃない場合は、処理しない
        if (!GameSystem.IsPlaying) return;

        // wpos = 目的の座標。ここに移動させたい
        Vector3 mpos = Input.mousePosition;
        mpos.z = -Camera.main.transform.position.z;
        Vector3 wpos = Camera.main.ScreenToWorldPoint(mpos);

        // 距離を求める
        Vector3 dist = wpos - transform.position;
        // 時間 Time.fixedDeltaTime = 0.016666....が大体入っている

        Vector3 vel = dist / Time.fixedDeltaTime;

        // 最高速度をチェックする
        float nextspd = vel.magnitude;
        if (nextspd > Speed)
        {
            vel = vel.normalized * Speed;
        }

        rb.velocity = vel;
    }

    private void OnDrawGizmos()
    {
        Vector3 mpos = Input.mousePosition;
        mpos.z = -Camera.main.transform.position.z;
        Vector3 wpos = Camera.main.ScreenToWorldPoint(mpos);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(wpos, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // プレイ中じゃない場合は、処理しない
        if (!GameSystem.IsPlaying) return;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            SEManager.Instance.Play(SEManager.SE.MISS);
            GameSystem.IsPlaying = false;
            if (prefMiss != null)
            {
                Instantiate(prefMiss, transform.position, Quaternion.identity);
            }
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        }
        else if (collision.gameObject.CompareTag("Item"))
        {
            SEManager.Instance.Play(SEManager.SE.EAT);
            if (prefItem != null)
            {
                Instantiate(prefItem, collision.transform.position, Quaternion.identity);
            }
            collision.gameObject.SendMessage("Pickup");
            // アイテムをすべて取っていたらクリア
            if (Item.Count <= 0)
            {
                GameSystem.IsPlaying = false;
                SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
            }
        }
    }


}
