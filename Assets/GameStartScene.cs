using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class GameStartScene : MonoBehaviour
{
    public void OnClickBack()
    {
        Debug.Log("뒤로가기");
        LoadingScene.LoadScene("MainMenuScene");
    }
    public void OnClickHigh()
    {
        Debug.Log("고급설정");
    }
    public void OnClickStart()
    {
        Debug.Log("시작하기");
        LoadingScene.LoadScene("GamePlayScene");
    }
}
