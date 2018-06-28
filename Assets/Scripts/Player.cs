using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// スコア
    /// </summary>
    public static int Score = 0;
    /// <summary>
    /// 残機
    /// </summary>
    public static int Life = 3;

    public Bullet bulletPrefab;

    public float move = 0.3f;
    public static float worldLeft, worldRight;
    public static float worldTop, worldBottom;

    /// <summary>
    /// ViewportToWorldPointの誤差
    /// </summary>
    const float worldRate = 0.85f;

    /// <summary>
    /// 撃墜されたときの残り無敵フレーム
    /// </summary>
    int remainReturn = 0;

    // Use this for initialization
    void Start()
    {
        Application.targetFrameRate = 60;

        var camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        var terrain = GameObject.FindGameObjectWithTag("Terrain");
        float distance = Vector3.Distance(camera.transform.position, terrain.transform.position);
        worldLeft = camera.ViewportToWorldPoint(new Vector3(0, 0, distance)).x * worldRate;
        worldRight = camera.ViewportToWorldPoint(new Vector3(1, 0, distance)).x * worldRate;
        worldTop = camera.ViewportToWorldPoint(new Vector3(0, 1, distance)).z * worldRate;
        worldBottom = camera.ViewportToWorldPoint(new Vector3(0, 0, distance)).z * worldRate;
        Debug.Log(worldLeft);
        Debug.Log(worldRight);
    }


    // Update is called once per frame
    void Update()
    {
        InputKeys();
        ReturnTime();
    }

    int remainShot = 0;

    /// <summary>
    /// キー入力による移動・攻撃
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

        // 攻撃
        if (remainShot <= 0 && Input.GetButton("Fire1"))
        {
            var b = Instantiate(bulletPrefab);
            b.transform.position = transform.position;
            remainShot = 30;
            // TODO:SE
        }
        remainShot--;
    }

    /// <summary>
    /// 被弾
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (remainReturn > 0)
            return;
        if (other.gameObject.tag == "EnemyBullet")
        {
            // TODO SE
            Life--;
            if (Life <= 0)
            {
                // GAME OVER
            }
            remainReturn = 60;
        }
    }

    void ReturnTime()
    {
        remainReturn--;
        if (remainReturn > 0)
        {
            if (remainReturn / 10 % 2 == 0)
                gameObject.transform.localScale = new Vector3(1, 1, 1);
            else
                gameObject.transform.localScale = Vector3.zero;
        }
    }
}

