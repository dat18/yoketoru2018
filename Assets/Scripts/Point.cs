using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour {

    public void DestroyMe()
    {
        Debug.Log("destroy");
        Destroy(gameObject);
    }
}
