using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycleScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Sun;

    [SerializeField]
    private GameObject Moon;

    private float ObjectMoving; // 초당 움직일 각도.

    private TimeManagerScript m_timeManager;

    private GameManagerScript m_gameManager;
    // Start is called before the first frame update
    void Start()
    {
        TimeManagerScript timeManager = GameObject.Find("TimeManager").GetComponent<TimeManagerScript>();

        DayNightCycleInit(timeManager.GetStartHour(), timeManager.GetStartMinute(), timeManager.GetEndHour(),
            timeManager.GetEndMinute(), timeManager.GetRealTimeForDay());

        Sun = GameObject.Find("Sun Light");
        Moon = GameObject.Find("Moon Light");

        Debug.Log("Start Cycle");
    }

    // Update is called once per frame
    void Update()
    {
        MovingObject();
    }

    IEnumerator RoutinCycle()
    {
        while(true)
        {
            MovingObject();
            yield return new WaitForSecondsRealtime(1.0f);
        }
    }

    public void MovingObject()
    {
        m_gameManager = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        if (m_gameManager.GetGameState() == GamePlayState.PLAYING)
        {
            Sun.transform.RotateAround(Vector3.zero, Vector3.right, ObjectMoving * Time.deltaTime);
            Sun.transform.LookAt(Vector3.zero);

            Moon.transform.RotateAround(Vector3.zero, Vector3.right, ObjectMoving * Time.deltaTime);
            Moon.transform.LookAt(Vector3.zero);
        }
    }

    public void DayNightCycleInit(int StartHour, int StartMinute, int EndHour, int EndMinute, int dayToRealTime)
    {
        float degree;
        degree = StartHour * 15f + StartMinute * 0.25f;

        // 초기화
        Sun.transform.position = new Vector3(0.0f, -500f, 0.0f);
        Moon.transform.position = new Vector3(0.0f, 500f, 0.0f);

        Sun.transform.RotateAround(Vector3.zero, Vector3.right, degree);
        Moon.transform.RotateAround(Vector3.zero, Vector3.right, degree);

        // 움직임 계산
        int hourDiff = EndHour - StartHour;
        int minuteDiff;
        if (StartMinute > EndMinute)
        {
            minuteDiff = -(EndMinute - StartMinute);
            hourDiff--;
        }
        else
            minuteDiff = EndMinute - StartMinute;

        float AllDegree = hourDiff * 15f + minuteDiff * 0.25f;
        ObjectMoving = AllDegree / (float)dayToRealTime;
    }

    public void StartRoutine()
    {
        StartCoroutine(RoutinCycle());
    }

    public void StopRoutine()
    {
        StopCoroutine(RoutinCycle());
    }
}
