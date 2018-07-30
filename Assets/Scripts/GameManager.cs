using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    [TooltipAttribute("最初に獲得できる点数"), SerializeField]
    private float INIT_POINT = 100f;

    [TooltipAttribute("1秒経過ごとに何点獲得点数を減らすか"), SerializeField]
    private float TIME_GENTEN = 10f;

    [TooltipAttribute("得点プレハブ"), SerializeField]
    private GameObject prefPoint;

    [Tooltip("得点を表示する範囲"), SerializeField]
    private Bounds pointBounds;

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(pointBounds.center, pointBounds.size);
    }
#endif

    public static float NowPoint
    {
        get;
        private set;
    }

    private void Awake()
    {
        Instance = this;
        Item.ClearCount();
    }

    // Use this for initialization
    void Start () {
        NowPoint = INIT_POINT;
        GameSystem.Instance.ClearScore();
        GameSystem.IsPlaying = true;
        Time.timeScale = 1f;
    }

    private void FixedUpdate()
    {
        if (!GameSystem.IsPlaying) return;

        // 減点
        NowPoint -= Time.fixedDeltaTime * TIME_GENTEN;
        NowPoint = Mathf.Max(NowPoint, 1f);
    }

    public void StopBGM()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void DrawPoint(Vector3 pos, int point)
    {
        pos.x = Mathf.Clamp(pos.x, pointBounds.min.x, pointBounds.max.x);
        pos.y = Mathf.Clamp(pos.y, pointBounds.min.y, pointBounds.max.y);
        pos.z = -1f;
        GameObject go = Instantiate<GameObject>(prefPoint, pos, Quaternion.identity);
        go.GetComponentInChildren<TextMeshPro>().text = ""+point;
    }
}
