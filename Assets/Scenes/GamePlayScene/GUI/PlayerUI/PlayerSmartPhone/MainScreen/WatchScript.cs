using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchScript : MonoBehaviour
{
    Text Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeManagerScript timeManager = GameObject.Find("TimeManager").GetComponent<TimeManagerScript>();
        Text = GameObject.Find("WatchText").GetComponent<Text>();

        float time = timeManager.GetDayTime();
        int Hour = (int)time / 3600;
        int Minute = (((int)time) % 3600) / 60;

        Text.text = Hour + " : " + Minute;
        
    }
}
