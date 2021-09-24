using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ride", menuName = "New Ride/ride")]
public class Ride : ScriptableObject
{
    // 표시될 이동수단 이름
    public string Name = "New Ride";
    // 이동 속도
    public double BaseSpeed = 1.0;
    // 이동수단 유지비
    public int MaintenanceFee = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
