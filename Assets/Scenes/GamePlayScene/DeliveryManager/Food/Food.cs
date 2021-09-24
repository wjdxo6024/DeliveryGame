using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "New Food/food")]
public class Food : ScriptableObject
{
    // 표시될 음식 이름
    public string Name = "New Food";
    // 음식의 레벨 (하급 < 중급 < 고급)
    public int Level = 0;

    public int FoodPrice;
}
