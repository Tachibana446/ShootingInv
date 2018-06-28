using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    GameObject panel;

    // Use this for initialization
    void Start()
    {
        panel = GameObject.FindGameObjectWithTag("GameOverPanel");
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isClear)
        {
            var text = panel.GetComponentInChildren<Text>();
            text.text = "GAME CLEAR!!";
            panel.SetActive(true);
        }
        else if (Player.Life <= 0)
        {
            panel.SetActive(true);
        }
    }
}
