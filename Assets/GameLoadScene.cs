using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoadScene : MonoBehaviour
{
    public void OnClickBack()
    {
        Debug.Log("뒤로가기");
        LoadingScene.LoadScene("MainMenuScene");
    }
    public void OnClickDelete()
    {
        Debug.Log("삭제하기");
    }
    public void OnClickLoad()
    {
        Debug.Log("불러오기");
        LoadingScene.LoadScene("GamePlayScene");
    }
}
