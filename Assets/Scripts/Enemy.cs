using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 敵機
/// </summary>
public class Enemy : MonoBehaviour
{

    public int Score;
    public bool isDead = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(float x, float y)
    {
        var newPos = transform.position;
        newPos.x += x; newPos.y += y;
        transform.position = newPos;
    }
}
