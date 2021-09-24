using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagerScript : MonoBehaviour
{
    /*
     * 하루동안 소요될 실 플레이 시간 = 게임내 n시간
     */
    public float timer;
    public int seconds;

    private float CurrentDayTime; // 초 단위
    private int CurrentDays; // 날짜
    private float TimeFrame; // 현재 흐르고 있는 시간을 게임적으로 어떻게 반영할 프레임
    public int DayToRealTime; // 하루동안 소요될 실 플레이 시간, 초 단위.

    public int StartHour; // 하루 시작시 시간
    public int StartMinute; // 하루 시작시 분
    public int EndHour; // 하루 종료시 시간
    public int EndMinute; // 하루 종료시 분

    private float StartTimeForSecond;
    private float EndTimeForSecond;

    private float nextTime = 0.0f;
    private float TimeLeft = 0.0f;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentDays = 0;
        timer = 0.0f;

        StartTimeForSecond = StartHour * 60f * 60f + StartMinute * 60f;
        EndTimeForSecond = EndHour * 60f * 60f + EndMinute * 60f;
        // TimeFrame 계산
        TimeFrame = (EndTimeForSecond - StartTimeForSecond) / DayToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 매니저를 불러서 현재 상태를 체크
        GameManagerScript gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        // 플레이어가 진행 중.
        if (gm.GetGameState() == GamePlayState.PLAYING)
        {
            // 게임 시간과 실시간을 맞춰야 한다.
            timer += Time.deltaTime;
            seconds = (int)(timer % DayToRealTime);

            CurrentDayTime = StartTimeForSecond + TimeFrame * timer;

            // 시간이 지날 경우 종료 다음날로.
            if(CurrentDayTime >= EndTimeForSecond)
            {
                gm.SetGameState(GamePlayState.DAYOVER);
            }
        }
    }

    public void Save()
    {

    }

    public void StartDay()
    {
        timer = 0.0f;
        CurrentDayTime = 0f;
        CurrentDayTime = StartHour * 60f * 60f + StartMinute * 60f; // CurrentDayTime은 초단위
        CurrentDays++;
    }

    public void EndDay()
    {
       // 정산


    }

    public int GetDays()
    {
        return CurrentDays;
    }

    public float GetDayTime()
    {
        return CurrentDayTime;
    }

    public int GetStartHour()
    {
        return StartHour;
    }

    public int GetEndHour()
    {
        return EndHour;
    }

    public int GetStartMinute()
    {
        return StartMinute;
    }

    public int GetEndMinute()
    {
        return EndMinute;
    }

    public int GetRealTimeForDay()
    {
        return DayToRealTime;
    }

    public void InitTimeManager()
    {

    }

    public bool IsPassedSeconds(float second)
    {
        if (true)
        {
            return true;
        }
        else
            return false;
    }
}
