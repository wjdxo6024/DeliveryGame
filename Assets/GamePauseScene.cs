using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseScene : MonoBehaviour
{
    public static bool isPause = false; // 메뉴가 호출되면 true
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                //Debug.Log("창닫기");
                CloseMenu();
            }

            else
            {
                //Debug.Log("창열기");
                CallMenu();
            }
        }
    }
    void CloseMenu()
    {
        PauseMenuUI.gameObject.SetActive(false);
        Time.timeScale = 1f;
        isPause = false;
    }
    void CallMenu()
    {
        PauseMenuUI.gameObject.SetActive(true);
        Time.timeScale = 0f;
        isPause = true;
    }
    public void OnClickSave()
    {
        Debug.Log("게임 세이브");
    }
    public void OnClickLoad()
    {
        Debug.Log("게임 로드");
        //LoadingScene.LoadScene("GameLoadScene");
    }
    public void OnClickOption()
    {
        Debug.Log("옵션");
        //LoadingScene.LoadScene("OptionScene");
    }
    public void OnClickMainMenu()
    {
        Debug.Log("메인 메뉴");
        LoadingScene.LoadScene("MainMenuScene");
    }
    public void OnClickQuit()
    {
        Debug.Log("종료");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
