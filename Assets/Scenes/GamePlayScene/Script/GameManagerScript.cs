using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public enum GamePlayState { NOTHING, DAYBEGIN, PLAYING, PAUSE, DAYOVER, GAMEOVER};
public enum PlayerVehicleState { CAR, MOTORBIKE, BIKE, WALK};
public class GameManagerScript : MonoBehaviour
{
    private GamePlayState m_GameState;
    private PlayerVehicleState m_PlayerVehicleState;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    { 

        SetGameState(GamePlayState.DAYBEGIN);

        Debug.Log("GameManger State: " + m_GameState);
    }

    // Update is called once per frame
    void Update()
    {
        //TimeManagerScript timeManager = GameObject.Find("TimeManager").GetComponent<TimeManagerScript>();
        //if(m_GameState == GamePlayState.PLAYING)
        //{

        //}
    }

    public void ShowSpeed(float speed)
    {
        // m_SpeedUIText.text = "Speed: " + (int)speed + " km/h";
    }

    public GamePlayState GetGameState()
    {
        return m_GameState;
    }

    public void SetGameState(GamePlayState state)
    {
        m_GameState = state;

        // SceneChagne
        PlaySceneManagerScript playSceneManager = GameObject.Find("PlaySceneManager").GetComponent<PlaySceneManagerScript>();
        playSceneManager.SceneChange();
    }

    public void SetVeicleState(PlayerVehicleState state)
    {
        m_PlayerVehicleState = state;
    }
}
