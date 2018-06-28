using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float Speed = 0.5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        pos.z += Speed;
        transform.position = pos;

        // 範囲外で消去
        if (transform.position.x > 30 || transform.position.x < -30 ||
            transform.position.z > 30 || transform.position.z < -30)
        {
            Destroy(this.gameObject);
        }
    }
}
