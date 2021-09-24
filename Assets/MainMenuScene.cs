using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class MainMenuScene : MonoBehaviour
{
    //int MainMenuSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        //MainMenuSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewGame()
    {
        Debug.Log("새 게임");
        LoadingScene.LoadScene("GameStartScene");
    }

    public void OnClickLoad()
    {
        Debug.Log("게임 로드");
        LoadingScene.LoadScene("GameLoadScene");
    }

    public void OnClickOption()
    {
        Debug.Log("옵션");
        LoadingScene.LoadScene("OptionScene");
    }

    public void OnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
