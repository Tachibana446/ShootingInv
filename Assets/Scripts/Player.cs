using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float move = 0.3f;
    private float worldLeft, worldRight;
    /// <summary>
    /// ViewportToWorldPointの誤差
    /// </summary>
    const float worldRate = 0.85f;

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;

        var camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        var terrain = GameObject.FindGameObjectWithTag("Terrain");
        float distance = Vector3.Distance(camera.transform.position, terrain.transform.position);
        worldLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, distance)).x * worldRate;
        worldRight = camera.ViewportToWorldPoint(new Vector3(1, 0, distance)).x * worldRate;
        Debug.Log(worldLeft);
        Debug.Log(worldRight);
    }


    // Update is called once per frame
    void Update()
    {
        InputKeys();
    }

    /// <summary>
    /// キー入力による移動
    /// </summary>
    void InputKeys()
    {
        var pos = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= move;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += move;
        }
        // 境界チェック
        if (pos.x > worldRight)
            pos.x = worldRight;
        else if (pos.x < worldLeft)
            pos.x = worldLeft + 1f;
        // 反映
        transform.position = pos;
    }
}

