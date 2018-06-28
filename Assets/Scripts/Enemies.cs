using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// 敵を生み出して動かすやつ
/// </summary>
public class Enemies : MonoBehaviour
{
    public Enemy enemyPrefab;
    private List<Enemy> enemyList = new List<Enemy>();

    int frame = 0;
    float spaceX = (Player.worldRight - Player.worldLeft) / 12f;
    float spaceY = (Player.worldTop - Player.worldBottom) / 11f;

    bool isAppeared = false;
    float moveDistance = 0.5f;
    Direction MoveDir = Direction.Right;
    Direction nextDir;
    int downRemain;
    int speed = 60;

    // Use this for initialization
    void Start()
    {
        if (enemyPrefab == null)
            Debug.LogError("エネミーのプレハブが未設定です");

    }

    int remainMoveFrame = 60;
    // Update is called once per frame

    void Update()
    {
        if (!isAppeared)
            Appear();

        SetSpeed();

        remainMoveFrame--;
        if (remainMoveFrame == 0)
        {
            Move();
            remainMoveFrame = speed;
        }
        frame++;
    }

    void Appear()
    {
        // Init
        if (spaceX == 0 || spaceY == 0)
        {
            spaceX = (Player.worldRight - Player.worldLeft) / 12f;
            spaceY = (Player.worldTop - Player.worldBottom) / 11f;
        }
        // Create
        for (int x = 0; x < 11; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                var enemy = Instantiate(enemyPrefab);
                enemy.transform.position = new Vector3(Player.worldLeft + spaceX * x, 0, Player.worldTop - spaceY * y);
                enemy.Score = y == 0 ? 30 : y < 3 ? 20 : 10;
                enemyList.Add(enemy);
            }
        }
        isAppeared = true;
    }

    void SetSpeed()
    {
        enemyList.RemoveAll(e => e.isDead);
        if (enemyList.Count == 1)
            speed = 3;
        else if (enemyList.Count < 10)
            speed = 6;
        else if (enemyList.Count < 30)
            speed = 30;
    }

    void Move()
    {
        if (MoveDir == Direction.Right)
        {
            enemyList.ForEach(e => e.Move(moveDistance, 0));
            if (enemyList.Any(e => e.transform.position.x >= Player.worldRight))
            {
                nextDir = Direction.Left;
                MoveDir = Direction.Down;
                downRemain = (int)(1f / moveDistance);
            }
        }
        else if (MoveDir == Direction.Left)
        {
            enemyList.ForEach(e => e.Move(-moveDistance, 0));
            if (enemyList.Any(e => e.transform.position.x <= Player.worldLeft))
            {
                nextDir = Direction.Right;
                MoveDir = Direction.Down;
                downRemain = (int)(1f / moveDistance);
            }
        }
        else if (MoveDir == Direction.Down)
        {
            enemyList.ForEach(e => e.Move(0, -moveDistance));
            downRemain--;
            if (downRemain == 0)
                MoveDir = nextDir;
            if (enemyList.Any(e => e.transform.position.z < Player.worldBottom))
            {
                // Game Over
            }
        }
    }

    enum Direction
    {
        Right, Left, Down
    }
}
