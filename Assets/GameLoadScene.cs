using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoadScene : MonoBehaviour
{
    public void OnClickBack()
    {
        Debug.Log("�ڷΰ���");
        LoadingScene.LoadScene("MainMenuScene");
    }
    public void OnClickDelete()
    {
        Debug.Log("�����ϱ�");
    }
    public void OnClickLoad()
    {
        Debug.Log("�ҷ�����");
        LoadingScene.LoadScene("GamePlayScene");
    }
}
