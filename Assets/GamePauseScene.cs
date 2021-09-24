using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseScene : MonoBehaviour
{
    public static bool isPause = false; // �޴��� ȣ��Ǹ� true
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause)
            {
                //Debug.Log("â�ݱ�");
                CloseMenu();
            }

            else
            {
                //Debug.Log("â����");
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
        Debug.Log("���� ���̺�");
    }
    public void OnClickLoad()
    {
        Debug.Log("���� �ε�");
        //LoadingScene.LoadScene("GameLoadScene");
    }
    public void OnClickOption()
    {
        Debug.Log("�ɼ�");
        //LoadingScene.LoadScene("OptionScene");
    }
    public void OnClickMainMenu()
    {
        Debug.Log("���� �޴�");
        LoadingScene.LoadScene("MainMenuScene");
    }
    public void OnClickQuit()
    {
        Debug.Log("����");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
