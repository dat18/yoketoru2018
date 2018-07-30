using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrMover : MonoBehaviour {

    [SerializeField]
    private float MinSpeed = 2f;
    [SerializeField]
    private float MaxSpeed = 5f;

    private Rigidbody rb;

    private float MySpeed;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();

        // 初期速度を算出
        float th = Random.Range(0f, 360f);
        float spd = Random.Range(MinSpeed, MaxSpeed);
        Vector3 vel = rb.velocity;
        vel.x = Mathf.Cos(th * Mathf.Deg2Rad) * spd;
        vel.y = Mathf.Sin(th * Mathf.Deg2Rad) * spd;
        vel.z = 0f;
        rb.velocity = vel;

        MySpeed = spd;
    }

    void FixedUpdate()
    {
        float now = rb.velocity.magnitude;
        if (Mathf.Approximately(now, MySpeed) == false)
        {
            Vector3 vel = rb.velocity.normalized;
            rb.velocity = vel * MySpeed;
        }
    }

}
