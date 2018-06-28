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

    public void Move(float x, float z)
    {
        var newPos = transform.position;
        newPos.x += x; newPos.z += z;
        transform.position = newPos;
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Bullet")
        {
            Player.Score += Score;
            isDead = true;
            Destroy(other.gameObject);
            // TODO:SE

            Destroy(this.gameObject);
        }
    }

}
