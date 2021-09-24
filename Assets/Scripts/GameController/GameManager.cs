using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 게임 매니저는 싱글톤 인스턴스를 통해 참조할 수 있도록 작성한다.
// ESC 입력으로 인해 게임을 일시 정지할 때) `GameManager.Instance.PauseGame();`
public class GameManager
{
    private static GameManager instance;
    
    // 인스턴스 반환 함수
    public static GameManager Instance
    {
        get
        {
            if(null == instance)
            {
                instance = new GameManager();
            }
            return instance;
        }
    }

    // 매니저 생성자
    public GameManager()
    {
        this.InitGame();
    }

    // 게임 초기화 함수
    public void InitGame() 
    {

    }

    // 게임 중단 시 호출되는 함수
    // e.g. ESC키로 인해 게임 중단 시 호출
    public void PauseGame()
    {

    }

    // 중단된 게임이 재개될 때 호출되는 함수
    public void ContinueGame()
    {

    }

    // 게임 재시작 시 호출되는 함수
    public void RestartGame()
    {

    }

    // 게임 종료 시 호출되는 함수
    public void StopGame()
    {

    }
}
