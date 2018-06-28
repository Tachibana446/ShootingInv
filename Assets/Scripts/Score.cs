using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var text = GetComponent<Text>();
        text.text = "SCORE: " + Player.Score + "\n残機: " + Player.Life;
    }
}
