using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class GameStartScene : MonoBehaviour
{
    public void OnClickBack()
    {
        Debug.Log("�ڷΰ���");
        LoadingScene.LoadScene("MainMenuScene");
    }
    public void OnClickHigh()
    {
        Debug.Log("��޼���");
    }
    public void OnClickStart()
    {
        Debug.Log("�����ϱ�");
        LoadingScene.LoadScene("GamePlayScene");
    }
}
