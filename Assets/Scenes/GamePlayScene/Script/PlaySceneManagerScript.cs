using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlaySceneManagerScript : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange()
    {
        GameManagerScript gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        switch(gameManagerScript.GetGameState())
        {
            case GamePlayState.DAYBEGIN:
                {
                    SceneManager.LoadScene("DayStartScene");

                    // �Ϸ� �ð� �ʱ�ȭ
                    TimeManagerScript timeManager = GameObject.Find("TimeManager").GetComponent<TimeManagerScript>();
                    timeManager.StartDay();
                }
                break;
            case GamePlayState.PLAYING:
                {
                    SceneManager.LoadScene("DayProceedingScene");
                }
                break;
            case GamePlayState.DAYOVER:
                {
                    SceneManager.LoadScene("DayEndScene");

                    // �Ϸ� �ð� ����
                    TimeManagerScript timeManager = GameObject.Find("TimeManager").GetComponent<TimeManagerScript>();
                    timeManager.EndDay();
                }
                break;
            case GamePlayState.GAMEOVER:
                {
                    SceneManager.LoadScene("GameOverScene");

                }
                break;
            case GamePlayState.PAUSE:
                {

                }
                break;
            
        }
    }
}
