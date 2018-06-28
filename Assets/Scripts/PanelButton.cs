using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelButton : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void Restart()
    {
        Player.Init();
        SceneManager.LoadScene("GameScene");

    }
}
