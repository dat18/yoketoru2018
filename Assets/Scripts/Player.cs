using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate () {
        // wpos = 目的の座標。ここに移動させたい
        Vector3 mpos = Input.mousePosition;
        mpos.z = -Camera.main.transform.position.z;
        Vector3 wpos = Camera.main.ScreenToWorldPoint(mpos);

        // 距離を求める
        Vector3 dist = wpos - transform.position;
        // 時間 Time.fixedDeltaTime = 0.016666....が大体入っている

        Vector3 vel = dist / Time.fixedDeltaTime;

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

}
