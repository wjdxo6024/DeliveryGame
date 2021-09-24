using System;
using System.Timers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManagerScript : MonoBehaviour
{
    /*
     * �Ϸ絿�� �ҿ�� �� �÷��� �ð� = ���ӳ� n�ð�
     */
    public float timer;
    public int seconds;

    private float CurrentDayTime; // �� ����
    private int CurrentDays; // ��¥
    private float TimeFrame; // ���� �帣�� �ִ� �ð��� ���������� ��� �ݿ��� ������
    public int DayToRealTime; // �Ϸ絿�� �ҿ�� �� �÷��� �ð�, �� ����.

    public int StartHour; // �Ϸ� ���۽� �ð�
    public int StartMinute; // �Ϸ� ���۽� ��
    public int EndHour; // �Ϸ� ����� �ð�
    public int EndMinute; // �Ϸ� ����� ��

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
        // TimeFrame ���
        TimeFrame = (EndTimeForSecond - StartTimeForSecond) / DayToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �Ŵ����� �ҷ��� ���� ���¸� üũ
        GameManagerScript gm = GameObject.Find("GameManager").GetComponent<GameManagerScript>();

        // �÷��̾ ���� ��.
        if (gm.GetGameState() == GamePlayState.PLAYING)
        {
            // ���� �ð��� �ǽð��� ����� �Ѵ�.
            timer += Time.deltaTime;
            seconds = (int)(timer % DayToRealTime);

            CurrentDayTime = StartTimeForSecond + TimeFrame * timer;

            // �ð��� ���� ��� ���� ��������.
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
        CurrentDayTime = StartHour * 60f * 60f + StartMinute * 60f; // CurrentDayTime�� �ʴ���
        CurrentDays++;
    }

    public void EndDay()
    {
       // ����


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
